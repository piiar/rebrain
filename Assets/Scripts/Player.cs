﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour {

    private readonly int speedHash = Animator.StringToHash("Speed");
    private readonly int pickupHash = Animator.StringToHash("PickUp");

    float rotationSpeed = 12f;
    float moveSpeed = 6f;

    GameObject carriedObject = null;

    private ItemTrigger itemFinder;
    private new Rigidbody2D rigidbody;
    private Animator animator;

    private bool animationFreezeActive;

    private Transform carryItemTransform;

    public Vector3 CarryItemPosition => carryItemTransform.position;

    // Start is called before the first frame update
    void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        itemFinder = GetComponentInChildren<ItemTrigger>();

        carryItemTransform = transform.Find("CarryItemPosition");
    }

    // Update is called once per frame
    public void Move(Vector2 moveDirection, bool interaction) {
        if (UIManager.instance.isPaused || animationFreezeActive) {
            return;
        }

        ApplyRotationTo(moveDirection);

        // Move the controller
        var movement = moveDirection * moveSpeed * Time.deltaTime;

        rigidbody.MovePosition(new Vector2(transform.position.x + movement.x, transform.position.y + movement.y));

        if (interaction) {
            HandleInteraction();
        }

        // Prevent the player for spinning due to physics issues when moving stuff and colliding
        //rigidbody.velocity = Vector3.zero;
        //rigidbody.angularVelocity = 0f;

        //animator.SetFloat(speedHash, Mathf.Min(moveDirection.magnitude, 1f));
    }

    private void ApplyRotationTo(Vector3 targetPosition) {
        //Vector3 repositioning = targetPosition;
        //if (repositioning != Vector3.zero) {
        //    repositioning.y = 0;
        //    Quaternion targetRotation = Quaternion.LookRotation(repositioning, Vector3.up);
        //    rigidbody.MoveRotation(Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime));
        //}
    }

    private void HandleInteraction() {
        //Item item = itemFinder.LastItem;
        //if (item) {
        //    PlayerAction action = null;
        //    switch (item.itemType) {
        //        case ItemType.Foodbowl:
        //            // This if check shouldn't be necessary as bowls
        //            // don't have any normal use action.
        //            if (HasItem(ItemType.Water) || HasItem(ItemType.Food)) {
        //                var bowl = item.GetComponent<BowlScript>();
        //                action = bowl.PlayerAction;
        //            }
        //            break;
        //        case ItemType.Dishtable:
        //            var dishtable = item.GetComponent<DishtableScript>();
        //            action = dishtable.PlayerAction;
        //            break;
        //        case ItemType.Fridge:
        //            var fridge = item.GetComponent<FridgeScript>();
        //            action = fridge.PlayerAction;
        //            break;
        //        case ItemType.Drawer:
        //            var drawer = item.GetComponent<DrawerScript>();
        //            action = drawer.PlayerAction;
        //            break;
        //        case ItemType.Furniture:
        //            // Without this check action is always defined
        //            // and furniture can't be picked up.
        //            if (HasItem(ItemType.Repair)) {
        //                action = item.PlayerRepairAction;
        //            }
        //            break;
        //    }

        //    if (action != null) {
        //        action(this, item);
        //    }
        //    else if (!carriedObject && item.isCarryable) {
        //        // Pick up
        //        PickupItem(item);

        //    }
        //}
        //if (!item && carriedObject != null) {
        //    // Drop
        //    animationFreezeActive = true;
        //    StartCoroutine(togglePickupAnimation(() => {
        //        animator.SetLayerWeight(1, 0f);
        //        carriedObject.transform.SetParent(null);
        //        Item _item = carriedObject.GetComponent<Item>();
        //        _item.DroppedDown();
        //        carriedObject = null;
        //        animationFreezeActive = false;
        //    }));
        //}
    }

    public bool HasItem(ItemType itemType) {
        return carriedObject && GetCarriedItem().itemType == itemType;
    }

    IEnumerator togglePickupAnimation(System.Action callback) {
        animator.SetTrigger(pickupHash);
        yield return new WaitForSeconds(0.5f);
        callback();
    }

    private void PickupItem(Item item) {
        animationFreezeActive = true;
        StartCoroutine(togglePickupAnimation(() => {
            animator.SetLayerWeight(1, 1f);
            item.gameObject.transform.SetParent(transform);
            carriedObject = item.gameObject;
            item.PickedUp();
            animationFreezeActive = false;
        }));
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
