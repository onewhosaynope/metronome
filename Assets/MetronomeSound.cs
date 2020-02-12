using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetronomeSound : MonoBehaviour {

    public AudioSource sound;

    void OnTriggerEnter(Collider collider) {
        sound.Play();
    }
}
