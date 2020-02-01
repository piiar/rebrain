using UnityEngine;
using System.Collections;

public class Meter : MonoBehaviour {
    public GameObject pointer;

    float amount = MeterManager.maxAmount / 2f;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void UpdateAmount(float _amount) {
        amount = _amount;
        // TODO set pointer rotation
    }
}
