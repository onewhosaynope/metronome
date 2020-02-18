using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

// wasd	             - movement
// o or k            - increase / decrease camera movement speed for 1f 
// p or l            - increase / decrease free look sensitivity
// right mouse  	 - enable free look camera
// left mouse button - shoot projectile from centre of screen to mouse position

public class FreeCam : MonoBehaviour 
{
    // Camera movement speed
    public float movementSpeed = 10f;
    
    // Sensitivity of camera in Free Look mode
    public float freeLookSensitivity = 3f;
    
    // Check-value for Free Look camera mode
    private bool freeLooking = false;
    
    // GameObject which is used as projectile.
    public GameObject prefab;
    
    // Amount of force applied to projectile.
    public float prefabSpeed;

    void Update()
    {
        // Shooting from camera to mouse position (KEY "LMB")
        if(Input.GetKey(KeyCode.Mouse0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit)) {
                Vector3 target = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                GameObject projectile = Instantiate(prefab, transform.position, Quaternion.LookRotation(target)) as GameObject;
                projectile.GetComponent<Rigidbody>().AddForce((target - projectile.transform.position) * prefabSpeed, ForceMode.Impulse);
            }
        }

        // Camera movement
        // move left (KEY "A")
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position + (-transform.right * movementSpeed * Time.deltaTime);
        }
        // move right (KEY "D")
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position + (transform.right * movementSpeed * Time.deltaTime);
        }
        // move forward (KEY "W")
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = transform.position + (transform.forward * movementSpeed * Time.deltaTime);
        }
        // move backwards (KEY "S")
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = transform.position + (-transform.forward * movementSpeed * Time.deltaTime);
        }

        
        // Free Look camera mode (KEY "RMB")
        // enter free look mode
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            freeLooking = true;
        }
        // exit free look mode
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            freeLooking = false;
        }
        
        if (freeLooking)
        {
            float newRotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * freeLookSensitivity;
            float newRotationY = transform.localEulerAngles.x - Input.GetAxis("Mouse Y") * freeLookSensitivity;
            transform.localEulerAngles = new Vector3(newRotationY, newRotationX, 0f);
        }
        
        
        // Camera movement speed
        // camera speed increasing (KEY "O")
        if (Input.GetKey(KeyCode.O))
        {
            movementSpeed = movementSpeed + 1F;
        }
        // camera speed decreasing (KEY "K")
        if (Input.GetKey(KeyCode.K))
        {
            movementSpeed = movementSpeed - 1F;
        }
        
        
        // Free Look sensitivity
        // free look increasing
        if (Input.GetKey(KeyCode.P))
        {
            freeLookSensitivity = freeLookSensitivity + 1F;
        }
        // free lock decreasing
        if (Input.GetKey(KeyCode.L))
        {
            freeLookSensitivity = freeLookSensitivity - 1F;
        }
    }

    
}
