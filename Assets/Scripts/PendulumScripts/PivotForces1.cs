using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// run at collisionExit
// pause at collisionEnter

public class PivotForces1 : MonoBehaviour
{
    public float amplitude = 20f;
    public float period = 2f;
    public bool rotate = false;
    public float step;
    private float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = 0.5f;
        step = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        if (rotate)
        {
            timer = timer + step;
            float angle2 = amplitude * Mathf.Cos(2 * Mathf.PI * timer / period);
            transform.localRotation = Quaternion.Euler(0f, angle2, 0f);
            Debug.Log(timer);
        }
    }


    /*private void OnCollisionEnter(Collision other)
    {
        rotate = false;
        Debug.Log(other.gameObject.name);
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "left")
        {
            step = -0.01f;
        } else if (other.gameObject.tag == "right")
        {
            step = 0.01f;
        }
        Debug.Log(transform.rotation.y);
        Debug.Log(transform.eulerAngles.y);
        rotate = true;
    } */
}