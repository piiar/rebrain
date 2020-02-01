using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProblemManager : MonoBehaviour {

    public GameObject ProblemObject;

    private float timeUntilNextProblem;
    private Transform goal;
    private Transform previousGoal;

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
        ProblemSpot[] items = FindObjectsOfType<ProblemSpot>();
        if (items.Length > 1) {
            do {
                int index = Random.Range(0, items.Length);
                goal = items[index].gameObject.transform;
            } while (goal == previousGoal);
        }
        else if (items.Length == 1) {
            goal = items[0].gameObject.transform;
        }
        else if (items.Length == 0) {
            goal = null;
        }
        previousGoal = goal;

        if (goal) {
            Debug.Log("Next goal: " + goal.gameObject.name);

            var problemObject = GameObject.Instantiate(ProblemObject);
            problemObject.transform.position = goal.position;
        }
    }

}
