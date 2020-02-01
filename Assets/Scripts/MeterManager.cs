using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeterManager : MonoBehaviour {
    public int electricAmount { get; private set; }
    public int drillAmount { get; private set; }

    private static MeterManager _instance;
    public static MeterManager instance {
        get {
            if (_instance == null) {
                _instance = Object.FindObjectOfType<MeterManager>();

                //Tell unity not to destroy this object when loading a new scene!
                DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }
    }

    public void IncreaseElectricMeter() {
        if (electricAmount < 10) {
            electricAmount++;
            UIManager.instance.UpdateElectricMeter(electricAmount);
        }
    }

    public void IncreaseDrillMeter() {
        if (drillAmount < 10) {
            drillAmount++;
            UIManager.instance.UpdateElectricMeter(drillAmount);
        }
    }

    public void DecreaseElectricMeter() {
        if (electricAmount > 0) {
            electricAmount--;
            UIManager.instance.UpdateElectricMeter(electricAmount);

        }
    }

    public void DecreaseDrillMeter() {
        if (drillAmount > 0) {
            drillAmount--;
            UIManager.instance.UpdateElectricMeter(drillAmount);
        }
    }
}
