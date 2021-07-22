using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveSizeExample : MonoBehaviour {

    [SerializeField] AnimationCurve curve;

    float t = 0, duration = 3f;
    int state = 0;

    void Start() {

    }

    void Update() {

        if (state == 0 && Input.GetButtonDown("Fire1")) {
            state = 1;
        } else if (state == 1) {
            // the time is normalized based on the duration
            float scalar = curve.Evaluate(t/duration); 
            transform.localScale = Vector3.one * scalar;
            t += Time.deltaTime; // Count time
            if (t >= duration) {
                state = 0;
                t = 0;
            }
        }
    }
}
