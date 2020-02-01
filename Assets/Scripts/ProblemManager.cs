﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProblemManager : MonoBehaviour {

    public GameObject ProblemObject;

    float timeUntilNextProblem;
    Transform spot;
    Transform previousSpot;

    // Update is called once per frame
    void Update() {

        if (UIManager.instance.isPaused) {
            return;
        }

        timeUntilNextProblem -= Time.deltaTime;

        if (timeUntilNextProblem <= 0f) {
            timeUntilNextProblem = Random.Range(5f, 10f);
            RandomizeSpot();
        }
    }

    private void RandomizeSpot() {
        // TODO find empty spots only
        ProblemSpot[] items = FindObjectsOfType<ProblemSpot>();
        if (items.Length > 1) {
            do {
                int index = Random.Range(0, items.Length);
                spot = items[index].gameObject.transform;
            } while (spot == previousSpot);
        }
        else if (items.Length == 1) {
            spot = items[0].gameObject.transform;
        }
        else if (items.Length == 0) {
            spot = null;
        }
        previousSpot = spot;

        if (spot) {
            //Debug.Log("Next spot: " + spot.gameObject.name);

            var problemObject = GameObject.Instantiate(ProblemObject);
            problemObject.transform.position = spot.position;
        }
    }

}
