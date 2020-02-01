using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProblemManager : MonoBehaviour {
    public GameObject DrillProblemObject;
    public GameObject WandProblemObject;

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
        ProblemSpot[] items = FindObjectsOfType<ProblemSpot>().Where(spot => spot.isInUse).ToArray();
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

            var problemObject = GameObject.Instantiate(DrillProblemObject);
            problemObject.transform.position = spot.position;
        }
    }

}
