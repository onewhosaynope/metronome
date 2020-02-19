using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpringScript : MonoBehaviour
{
    private HingeJoint hinge;
    // Start is called before the first frame update
    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        float y = transform.rotation.y;
    }

    // Update is called once per frame
    void Update()
    {
        var rotY = transform.localRotation.eulerAngles.y;
        rotY = rotY >= 180 ? rotY - 360 : rotY;

        if (rotY > 15)
        {
            Debug.Log($"More than 15 \nCurrent angle: {rotY}");
            var spring = hinge.spring;
            spring.targetPosition = -8;
            hinge.spring = spring;
        }
        else if (rotY < -15)
        {
            Debug.Log($"Less than -15 \nCurrent angle: {rotY}");
            var spring = hinge.spring;
            spring.targetPosition = 8;
            hinge.spring = spring;
        }
    }
}
