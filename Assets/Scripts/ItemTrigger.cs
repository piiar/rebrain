using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTrigger : MonoBehaviour {
    public Item LastItem { get; private set; }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("OnTriggerEnter");
        if (other.CompareTag("Item")) {
            Debug.Log("enter " + other.name);
            Item item = other.gameObject.GetComponent<Item>();
            if (item && (item.isCarryable || item.isFixable || item.isUsable)) {
                LastItem = item;
            }
            else {
                LastItem = null;
            }
            print("LastItem: " + (LastItem ? LastItem.name : "null"));
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Item")) {
            print("exit " + other.name);
            LastItem = null;
        }
    }
}
