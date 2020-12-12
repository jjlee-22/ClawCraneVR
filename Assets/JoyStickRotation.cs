using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickRotation : MonoBehaviour
{
    public GameObject primitive;
    float sensitivity = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rot = transform.rotation.eulerAngles;
        Vector3 p_rot = primitive.transform.rotation.eulerAngles;
        float x = 0;
        float z = 0;
        if (6 <= rot.x && rot.x < 31)
        {
            x = rot.x * sensitivity;
        }
        else if (rot.x >= 330 && rot.x <= 354)
        {
            x = -(60-rot.x+300) *sensitivity;
        }
        if (6 <= rot.z && rot.z < 31)
        {
            z = rot.z * sensitivity;
        }
        else if(rot.z >= 330 && rot.z <= 354)
        {
            z = -(60 - rot.z + 300) * sensitivity;
        }
        p_rot =p_rot + new Vector3(x, 0, z);
        primitive.transform.rotation = Quaternion.Euler(p_rot);
    }
}
