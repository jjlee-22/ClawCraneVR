using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneDirectionControl : MonoBehaviour
{
    public GameObject drone;
    float sensitivity = 0.001f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rot = transform.rotation.eulerAngles;
        Vector3 right = drone.transform.right;
        float x = 0;
        float z = 0;
        if (6 <= rot.x && rot.x < 31)
        {
            x = -rot.x * sensitivity;
        }
        else if (rot.x >= 330 && rot.x <= 354)
        {
            x = (60 - rot.x + 300) * sensitivity;
        }
        if (6 <= rot.z && rot.z < 31)
        {
            z = -rot.z * sensitivity;
        }
        else if (rot.z >= 330 && rot.z <= 354)
        {
            z = (60 - rot.z + 300) * sensitivity;
        }
        drone.transform.localPosition += drone.transform.forward * z;
        drone.transform.localPosition += drone.transform.right * x;
    }
}
