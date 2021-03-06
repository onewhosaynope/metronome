﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpringScript : MonoBehaviour
{
    private HingeJoint hinge;

    public float barrier = 15;
    public float target = 8;
    // Start is called before the first frame update
    void Start()
    {
        hinge = GetComponent<HingeJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        var rotY = transform.localRotation.eulerAngles.y;
        rotY = rotY >= 180 ? rotY - 360 : rotY;

        if (rotY > barrier)
        {
            Debug.Log($"More than 15 \nCurrent angle: {rotY}");
            var spring = hinge.spring;
            spring.targetPosition = -target;
            hinge.spring = spring;
        }
        else if (rotY < -barrier)
        {
            Debug.Log($"Less than -15 \nCurrent angle: {rotY}");
            var spring = hinge.spring;
            spring.targetPosition = target;
            hinge.spring = spring;
        }
    }
}
