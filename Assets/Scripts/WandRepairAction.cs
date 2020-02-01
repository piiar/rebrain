using UnityEngine;
using System.Collections;

public class WandRepairAction : Action {

    public void Execute(GameObject actor, Item target) {
        Debug.Log("---wand repair " + target.itemType);
        if (target.itemType == ItemType.WandProblem) {
            Debug.Log("WandRepairAction");
            GameObject.Destroy(target.gameObject);
        }
    }
}
