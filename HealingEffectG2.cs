using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingEffectG2 : MonoBehaviour {

    Animator animator;
    [SerializeField] ParticleSystem ps;
    [SerializeField] CameraShakeCurve cameraShake;
    [SerializeField] VFXCamera VFXCamera;

    int state = 0;
    float time = 0;

    void Awake() {
        animator = GetComponent<Animator>();
    }

    void Update() {

        if (state == 0 && Input.GetButtonDown("Fire1")) {
            state = 1;
            animator.SetTrigger("Cast");
            ps.Play();

        } else if (state == 1) {

            if (time >= 1.8f - 0.1f) {
                cameraShake.Activate();
                VFXCamera.Activate();
                state = 2;
            }
            time += Time.deltaTime;
        } else if (state == 2) {

            if (time >= 3f) {
                state = 0;
                time = 0;
            }
            time += Time.deltaTime;
        }
    }
}
