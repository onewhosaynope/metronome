using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchHandler : MonoBehaviour  {
    
    public Rigidbody target;
    public float thrust;

    Vector3 velocity;
    Vector3 impactForce;
    ContactPoint[] contacts;
    
    // Start is called before the first frame update
    void Start() {
        target = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (Input.GetKeyDown(KeyCode.N)) {
            target.AddForce(transform.right * thrust);
        }

        if (Input.GetKeyDown(KeyCode.M)) {
            target.AddForce(-(transform.right) * thrust);
        }

        if (Input.GetKeyDown(KeyCode.B)) {
            Debug.Log("velocity: " + velocity + "\nimpactForce: " + impactForce);
            Debug.Log("contacts: ");
            foreach (var contact in contacts) {
                Debug.Log(contact);
            }

            Debug.Log("angle" + transform.rotation);
        }
    }

    void OnCollisionEnter(Collision collision) {
        velocity = collision.relativeVelocity;
        impactForce = collision.impactForceSum;
        contacts = collision.contacts;
    }
}
