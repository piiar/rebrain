using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {
    private Player player;

    // Key pressed can only reliably be detected during Update()
    private bool interactionPressed = false;
    private bool fixPressed = false;

    // Start is called before the first frame update
    void Awake() {
        player = GetComponent<Player>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1")) {
            interactionPressed = true;
        }
        if (Input.GetKeyDown(KeyCode.F)) {
            fixPressed = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape)) {
            UIManager.instance.Pause();
        }
    }

    // Update is called once per frame
    void FixedUpdate() {
        // read inputs
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        bool interaction = Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1");
        Vector2 moveDirection = v * Vector2.up + h * Vector2.right;

        player.Move(moveDirection, interactionPressed, fixPressed);
        interactionPressed = false;
        fixPressed = false;
    }
}
