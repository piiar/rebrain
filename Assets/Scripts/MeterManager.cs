using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeterManager : MonoBehaviour {

    public float electricAmount { get; private set; }
    public float drillAmount { get; private set; }

    public const float maxAmount = 100f;
    private float elapsedTime = 0;

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

    void Update() {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= 1f) {
            elapsedTime = 0;
            DecreaseDrillMeter();
            DecreaseElectricMeter();
        }
    }

    public void IncreaseElectricMeter() {
        if (electricAmount < maxAmount) {
            electricAmount++;
            UIManager.instance.UpdateElectricMeter(electricAmount);
        }
    }

    public void IncreaseDrillMeter() {
        if (drillAmount < maxAmount) {
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
