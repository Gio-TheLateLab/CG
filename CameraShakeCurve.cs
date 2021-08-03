using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Script for shaking the camera when pressing Fire 1 button
// It uses a custom curve to simulate the movement
public class CameraShakeCurve : MonoBehaviour {
    
    [SerializeField] AnimationCurve curve;
    [SerializeField] float duration = 3, amplitude = 2;

    float time = 0;
    int state = 0;
    
    Camera camera; // The script is attached to the camera
    float initialFOV = 0;

    void Start() {
        camera = GetComponent<Camera>();
        initialFOV = camera.fieldOfView;
    }

    void Update() {

        // Here we evaluate the curve based on the normalized time
        if (state == 1) {
            float t = time / duration; // Normalize the time
            float y = curve.Evaluate(t) * amplitude;

            camera.fieldOfView = initialFOV + y;

            time += Time.deltaTime;
            if (t >= 1) { // Once it has finished we go to the initial state
                time = 0;
                state = 0;
            }
        }
    }

    public void Activate() {
        // If the state is 0 (it is not shaking already)
        // and we press Fire 1 we change to the state 1
        if (state == 0) {
            state = 1;
        }
    }
}
