using UnityEngine;
using System.Collections;

public class Meter : MonoBehaviour {
    public GameObject pointer;

    float amount = 0;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void UpdateAmount(float _amount) {
        amount = _amount;
    }
}
