using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderRight : MonoBehaviour
{
    public GameObject pivot;
    private PivotForces1 pivotValues;
    
    // Start is called before the first frame update
    void Start()
    {
        pivotValues = pivot.GetComponent<PivotForces1>();
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision other)
    {
        pivotValues.rotate = false;
        Debug.Log("Right collider Enter");
    }

    private void OnCollisionExit(Collision other)
    {
        pivotValues.step = -0.01f;
        pivotValues.rotate = true;
        Debug.Log("Right collider Exit");
    }
}
