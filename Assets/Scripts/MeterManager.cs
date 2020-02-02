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

    private void Start() {
        electricAmount = maxAmount / 2f;
        drillAmount = maxAmount / 2f;
        UIManager.instance.UpdateElectricMeter(electricAmount);
        UIManager.instance.UpdateDrillMeter(drillAmount);
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
            electricAmount += 10;
            UIManager.instance.UpdateElectricMeter(electricAmount);
        }
        else {
            AudioManager.instance.PlaySound("wandWarningSound");
            UIManager.instance.EndGame();
        }
    }

    public void IncreaseDrillMeter() {
        if (drillAmount < maxAmount) {
            drillAmount += 10;
            UIManager.instance.UpdateDrillMeter(drillAmount);
        }
        else {
            AudioManager.instance.PlaySound("drillWarningSound");
            UIManager.instance.EndGame();
        }
    }

    public void DecreaseElectricMeter() {
        if (electricAmount > 0) {
            electricAmount -= 1.5f;
            UIManager.instance.UpdateElectricMeter(electricAmount);
        }
        else {
            AudioManager.instance.PlaySound("wandWarningSound");
            UIManager.instance.EndGame();
        }
    }

    public void DecreaseDrillMeter() {
        if (drillAmount > 0) {
            drillAmount -= 1.5f;
            UIManager.instance.UpdateDrillMeter(drillAmount);
        }
        else {
            AudioManager.instance.PlaySound("drillWarningSound");
            UIManager.instance.EndGame();
        }
    }
}
