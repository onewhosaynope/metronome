using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpawner : MonoBehaviour {

    Ray ray;
    RaycastHit hit;
    public GameObject prefab;
    public float prefabSpeed;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if(Input.GetButtonDown("Fire1")) {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) {
                Vector3 target = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                GameObject projectile = Instantiate(prefab, Camera.main.transform.position, Quaternion.LookRotation(target)) as GameObject;
                projectile.GetComponent<Rigidbody>().AddForce((target - projectile.transform.position) * prefabSpeed, ForceMode.Impulse);
            }
        }

        if(Input.GetButtonDown("Fire2")) {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) {
                Instantiate(prefab, new Vector3(hit.point.x, hit.point.y, hit.point.z), Quaternion.identity);
            }
        }

        if (Input.GetButtonDown("Jump")) {
            Instantiate(prefab, Camera.main.transform.position, Camera.main.transform.rotation);
        }
    }
}