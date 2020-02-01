using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProblemManager : MonoBehaviour {
    public GameObject DrillProblemObject;
    public GameObject WandProblemObject;

    float timeUntilNextProblem;
    Transform spotTransform;
    ProblemSpot spot;

    // Update is called once per frame
    void Update() {

        if (UIManager.instance.isPaused) {
            return;
        }

        timeUntilNextProblem -= Time.deltaTime;

        if (timeUntilNextProblem <= 0f) {
            timeUntilNextProblem = Random.Range(2f, 5f);
            RandomizeSpot();
        }
    }

    private void RandomizeSpot() {
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
            int selectedType = Random.Range(0, 2);
            if (selectedType == 1) {
                AudioManager.instance.PlaySound("woundAppearSound");
                var problemObject = GameObject.Instantiate(WandProblemObject);
                problemObject.transform.position = spotTransform.position;
                Problem problem = problemObject.GetComponent<Problem>();
                problem.relatedSpot = spot;
            }
            else {
                AudioManager.instance.PlaySound("rockAppearSound");
                var problemObject = GameObject.Instantiate(DrillProblemObject);
                problemObject.transform.position = spotTransform.position;
                Problem problem = problemObject.GetComponent<Problem>();
                problem.relatedSpot = spot;
            }

        }
    }

}
