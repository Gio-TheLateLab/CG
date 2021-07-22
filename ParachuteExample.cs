using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParachuteExample : MonoBehaviour {

    Rigidbody rigidbody;
    Renderer renderer;
    ParticleSystem ps;

    void Start() {
        rigidbody = GetComponent<Rigidbody>();
        renderer = GetComponent<Renderer>();
        ps = GetComponentInChildren<ParticleSystem>();
    }

    void Update() {

        if (Input.GetButtonDown("Jump")) {
            rigidbody.drag = 10;
            renderer.material.color = Color.red;
            ps.Play();
        }

        if (Input.GetButtonUp("Jump")) {
            rigidbody.drag = 0;
            renderer.material.color = Color.white;
            ps.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }
        
    }
}
