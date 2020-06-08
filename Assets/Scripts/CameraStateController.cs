using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Random = UnityEngine.Random;

public class CameraStateController : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;
    public GameObject[] target;
    public GameObject randomTarget;
    
    // State durations and when to switch.
    public float stateDuration = 4f;
    public int random;
    public int prevRandom;
    
    // Update timer to start new states.
    private float counter = 0f;
    public List<CameraStates> states = new List<CameraStates>();

    private void Start() {
        // Fill list.
        states.Add(new CameraState_Diagonal_BottomLeft());
        states.Add(new CameraState_Diagonal_BottomRight());
        states.Add(new CameraState_Diagonal_TopLeft());
        states.Add(new CameraState_Diagonal_TopRight());
        states.Add(new CameraState_RotateLeft());
        states.Add(new CameraState_RotateRight());
        states.Add(new CameraState_SlideLeft());
        states.Add(new CameraState_SlideRight());
        states.Add(new CameraState_ZoomIn());
        states.Add(new CameraState_ZoomOut());
        
        // Attach first target.
        randomTarget = target[Random.Range(0, target.Length)];
        // Start first state.
        states[random].UpdateCamera(cam1, randomTarget, counter);
    }

    private void Update() {
        // Running counter.
        counter += Time.deltaTime;
        
        // If counter reaches the total duration of a state..
        if (counter >= stateDuration) {
            // Picks a random state.
            random = Random.Range(0, states.Count);
            randomTarget = target[Random.Range(0, target.Length)];
            if (random == prevRandom) {
                random = Random.Range(0, states.Count);
            }
            prevRandom = random;

            // Reset counter.
            counter = 0f;
        }
        states[random].UpdateCamera(cam1, randomTarget, stateDuration);
    }
}
