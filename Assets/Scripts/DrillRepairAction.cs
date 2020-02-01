using UnityEngine;
using System.Collections;

public class DrillRepairAction : Action {

    public void Execute(GameObject actor, Item target) {
        Debug.Log("---drill repair " + target.itemType);
        if (target.itemType == ItemType.DrillProblem) {
            Debug.Log("DrillRepairAction");
            Problem problem = target.gameObject.GetComponent<Problem>();
            problem.relatedSpot.isInUse = false;
            GameObject.Destroy(target.gameObject);
            MeterManager.instance.DecreaseDrillMeter();
        }
    }
}
