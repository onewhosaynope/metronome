using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderLeft : MonoBehaviour
{
    public GameObject pivot;
    private PivotForces1 pivotValues;
    
    // Start is called before the first frame update
    void Start()
    {
        pivotValues = pivot.GetComponent<PivotForces1>();
    }
    
    
    private void OnCollisionEnter(Collision other)
    {
        pivotValues.rotate = false;
        Debug.Log("Left collider Enter");
    }

    private void OnCollisionExit(Collision other)
    {
        pivotValues.step = 0.01f;
        pivotValues.rotate = true;
        Debug.Log("Left collider Exit");
        
    }
}
