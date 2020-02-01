using UnityEngine;
using System.Collections;

public class WandRepairAction : Action {

    public void Execute(GameObject actor, Item target) {
        if (target.itemType == ItemType.WandProblem) {
            Debug.Log("WandRepairAction");
            GameObject.Destroy(target.gameObject);
        }
    }
}
