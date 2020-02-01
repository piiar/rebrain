using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTrigger : MonoBehaviour {
    public Item LastItem { get; private set; }
    public Item LastProblem { get; private set; }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Item")) {
            //Debug.Log("enter " + other.name);
            Item item = other.gameObject.GetComponent<Item>();
            if (item && item.isCarryable) {
                LastItem = item;
                print("LastItem: " + LastItem.name);
            }
            else if (item && item.isFixable) {
                LastProblem = item;
                print("LastProblem: " + LastProblem.name);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Item")) {
            //Debug.Log("exit " + other.name);
            Item item = other.gameObject.GetComponent<Item>();
            if (item && item.isCarryable) {
                LastItem = null;
                print("LastItem: null");
            }
            else if (item && item.isFixable) {
                LastProblem = null;
                print("LastProblem: null");
            }
        }
    }
}
