using UnityEngine;
using System.Collections;

public class Meter : MonoBehaviour {
    public GameObject pointerContainer;

    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {

    }

    public void UpdateAmount(float amount) {
        float degrees = 180 * (100 - amount) / 100;
        Debug.Log("UpdateAmount " + amount + ", " + degrees);
        Quaternion rotation = Quaternion.Euler(0, 0, degrees);
        pointerContainer.transform.rotation = rotation;
    }
}
