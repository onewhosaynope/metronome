using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringScript : MonoBehaviour
{
    public GameObject pivot;
    private Quaternion angle;
    
    // Start is called before the first frame update
    void Start()
    {
        angle = pivot.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            angle.y =- 5;
            pivot.transform.rotation = angle;
        }
    }
}
