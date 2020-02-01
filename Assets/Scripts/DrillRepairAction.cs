using UnityEngine;
using System.Collections;

public class DrillRepairAction : Action {

    public void Execute(GameObject actor, Item target) {
        if (target.itemType == ItemType.DrillProblem) {
            Debug.Log("DrillRepairAction");
            GameObject.Destroy(target.gameObject);
        }
    }
}
