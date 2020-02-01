using UnityEngine;
using System.Collections;

public class WandRepairAction : Action {

    public void Execute(GameObject actor, Item target) {
        Debug.Log("---wand repair " + target.itemType);
        if (target.itemType == ItemType.WandProblem) {
            Debug.Log("WandRepairAction");
            Problem problem = target.gameObject.GetComponent<Problem>();
            problem.relatedSpot.isInUse = false;
            GameObject.Destroy(target.gameObject);
            MeterManager.instance.IncreaseElectricMeter();
        }
    }
}
