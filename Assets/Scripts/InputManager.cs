﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {
    private Player player;
    private float turnSmoothing = 0.1f;
    private float smoothX = 0;
    private float smoothY = 0;
    private float smoothXvelocity = 0;
    private float smoothYvelocity = 0;

    // Key pressed can only reliably be detected during Update()
    private bool interactionPressed = false;

    // Start is called before the first frame update
    void Awake() {
        player = GetComponent<Player>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1")) {
            interactionPressed = true;
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

        // float mouseX = Input.GetAxis("Mouse X");
        // float mouseY = Input.GetAxis("Mouse Y");

        // smoothX = Mathf.SmoothDamp(smoothX, mouseX, ref smoothXvelocity, turnSmoothing);
        // smoothY = Mathf.SmoothDamp(smoothY, mouseY, ref smoothYvelocity, turnSmoothing);

        bool interaction = Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1");
        Vector2 moveDirection = v * Vector2.up + h * Vector2.right;

        player.Move(moveDirection, interactionPressed);
        interactionPressed = false;
    }
}
