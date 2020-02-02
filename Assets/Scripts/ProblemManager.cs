using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProblemManager : MonoBehaviour {
    public GameObject DrillProblemObject;
    public GameObject WandProblemObject;

    float timeUntilNextWandProblem;
    float timeUntilNextDrillProblem;
    Transform spotTransform;
    ProblemSpot spot;

    // Update is called once per frame
    void Update() {

        if (UIManager.instance.isPaused) {
            return;
        }

        timeUntilNextWandProblem -= Time.deltaTime;
        timeUntilNextDrillProblem -= Time.deltaTime;

        if (timeUntilNextWandProblem <= 0f) {
            timeUntilNextWandProblem = Random.Range(3f, 7f);
            RandomizeSpot("wandProblem");
        }
        if (timeUntilNextDrillProblem <= 0f) {
            timeUntilNextDrillProblem = Random.Range(3f, 7f);
            RandomizeSpot("drillProblem");
        }
    }

    private void RandomizeSpot(string problemType) {
        ProblemSpot[] items = FindObjectsOfType<ProblemSpot>().Where(spot => !spot.isInUse).ToArray();

        if (items.Length > 1) {
            int index = Random.Range(0, items.Length);
            spotTransform = items[index].gameObject.transform;
            spot = items[index];
            items[index].isInUse = true;
        }
        else if (items.Length == 1) {
            spotTransform = items[0].gameObject.transform;
            spot = items[0];
            items[0].isInUse = true;
        }
        else if (items.Length == 0) {
            spotTransform = null;
        }

        if (spotTransform) {
            //Debug.Log("Next spot: " + spot.gameObject.name);
            if (problemType == "wandProblem") {
                AudioManager.instance.PlaySound("woundAppearSound");
                var problemObject = GameObject.Instantiate(WandProblemObject);
                problemObject.transform.position = spotTransform.position;
                problemObject.transform.rotation = Quaternion.Euler( 0 , 0 , Random.Range(-60, 60));
                Problem problem = problemObject.GetComponent<Problem>();
                problem.relatedSpot = spot;
            }
            else {
                AudioManager.instance.PlaySound("rockAppearSound");
                var problemObject = GameObject.Instantiate(DrillProblemObject);
                problemObject.transform.position = spotTransform.position;
                problemObject.transform.rotation = Quaternion.Euler( 0 , 0 , Random.Range(-45, 45));
                Problem problem = problemObject.GetComponent<Problem>();
                problem.relatedSpot = spot;
            }

        }
    }

}
