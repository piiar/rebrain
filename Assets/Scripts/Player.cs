using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour {

    private readonly int speedHash = Animator.StringToHash("Speed");
    private readonly int pickupHash = Animator.StringToHash("PickUp");

    float moveSpeed = 6f;

    GameObject carriedObject = null;

    private ItemTrigger itemFinder;
    private new Rigidbody2D rigidbody;

    private Transform carryItemTransform;

    public Vector2 CarryItemPosition => carryItemTransform.position;

    // Start is called before the first frame update
    void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
        itemFinder = GetComponentInChildren<ItemTrigger>();

        carryItemTransform = transform.Find("CarryItemPosition");
    }

    // Update is called once per frame
    public void Move(Vector2 moveDirection, bool interaction) {
        if (UIManager.instance.isPaused) {
            return;
        }

        // Move the controller
        if (moveDirection.x != 0 || moveDirection.y != 0) {
            ApplyRotationTo(moveDirection);
            var movement = moveDirection * moveSpeed * Time.deltaTime;
            rigidbody.MovePosition(new Vector2(transform.position.x + movement.x, transform.position.y + movement.y));
        }
        if (interaction) {
            HandleInteraction();
        }
        if (carriedObject) {
            UpdateCarriedItemPosition();
        }
    }

    private void UpdateCarriedItemPosition() {
        // apply the same rotation player has
        carriedObject.gameObject.transform.rotation = transform.rotation * Quaternion.Euler(0, 0, 90); // this adds a 90 degrees Y rotation;
        // re-position the item on our guide object 
        carriedObject.gameObject.transform.position = CarryItemPosition;

    }

    private void ApplyRotationTo(Vector2 moveDirection) {
        var angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        rigidbody.SetRotation(angle);
    }

    private void HandleInteraction() {
        Item item = itemFinder.LastItem;
        if (item) {
            Action action = null;
            switch (item.itemType) {
                case ItemType.DrillProblem:
                    if (HasItem(ItemType.Drill)) {
                        action = new DrillRepairAction();
                    }
                    break;
                case ItemType.WandProblem:
                    if (HasItem(ItemType.Wand)) {
                        action = new WandRepairAction();
                    }
                    break;
            }

            if (action != null) {
                action.Execute(this.gameObject, item);
            }
            else if (!carriedObject && item.isCarryable) {
                // Pick up
                PickupItem(item);

            }
            else if (carriedObject != null) {
                // Drop currently carried item
                DropItem();
            }
        }
    }

    public bool HasItem(ItemType itemType) {
        return carriedObject && GetCarriedItem().itemType == itemType;
    }

    private void PickupItem(Item item) {
        Debug.Log("PickupItem " + item.gameObject.name);
        item.gameObject.transform.SetParent(transform);

        // Set gravity to false while holding it
        item.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;

        carriedObject = item.gameObject;
        item.PickedUp();

        UpdateCarriedItemPosition();
    }

    private void DropItem() {
        Debug.Log("DropItem");
        carriedObject.transform.SetParent(null);
        // Restore gravity
        carriedObject.GetComponent<Rigidbody2D>().gravityScale = 1;

        Item _item = carriedObject.GetComponent<Item>();
        _item.DroppedDown();
        carriedObject = null;
    }

    public Item GetCarriedItem() {
        if (carriedObject) {
            return carriedObject.GetComponent<Item>();
        }
        return null;
    }

    public void SetCarriedItem(Item item) {
        if (!item) {
            carriedObject = null;
        }
        else if (!carriedObject) {
            PickupItem(item);
        }
    }
}
