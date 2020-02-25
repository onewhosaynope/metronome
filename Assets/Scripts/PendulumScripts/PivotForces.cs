using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// run at collisionExit
// pause at collisionEnter

public class PivotForces : MonoBehaviour
{
    public float amplitude = 20f;
    public float period = 2f;
    private bool collided = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (collided)
        {
            float angle2 = amplitude * Mathf.Cos(2 * Mathf.PI * Time.time / period);
            transform.localRotation = Quaternion.Euler(0f, angle2, 0f);
        }

        if (Input.GetKey(KeyCode.Z))
        {
            collided = false;
            
        } else if (Input.GetKey(KeyCode.X))
        {
            Debug.Log(transform.rotation.y);
            Debug.Log(transform.eulerAngles.y);
            collided = true;
        }
    }


    /*
    private void OnCollisionEnter(Collision other)
    {
        collided = false;
    }

    private void OnCollisionExit(Collision other)
    {
        Debug.Log(transform.rotation.y);
        Debug.Log(transform.eulerAngles.y);
        collided = true;
    } 
    */
}
