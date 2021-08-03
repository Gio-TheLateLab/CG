using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VFXCamera : MonoBehaviour {

    [SerializeField] AnimationCurve curve;
    [SerializeField] float duration = 3, amplitude = 2;

    Image image;
    int state = 0;
    float time = 0;
    Color color;

    void Start() {
        image = GetComponent<Image>();
        color = image.color;
    }

    void Update() {
        if (state == 1) {
            float t = time / duration; // Normalize the time
            float a = curve.Evaluate(t) * amplitude;

            Color currentColor = new Color(color.r, color.g, color.b, a);
            image.color = currentColor;

            time += Time.deltaTime;
            if (t >= 1) { // Once it has finished we go to the initial state
                time = 0;
                state = 0;
            }
        }

    }

    public void Activate() {
        if (state == 0) {
            state = 1;
        }
    }
}
