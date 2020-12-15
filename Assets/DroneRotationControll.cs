using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneRotationControll : MonoBehaviour
{
    public GameObject drone;
    public float sensitivity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        Vector3 d_rot = drone.transform.rotation.eulerAngles;
        float y = 0;
        if (6 <= rot.z && rot.z < 31)
        {
            y = -rot.z * sensitivity;
        }
        else if (rot.z >= 330 && rot.z <= 354)
        {
            y = (60 - rot.z + 300) * sensitivity;
        }
        Vector3 rot_vec = new Vector3(0, y, 0);
        d_rot += rot_vec;
        drone.transform.localRotation = Quaternion.Euler(d_rot);
    }
}
