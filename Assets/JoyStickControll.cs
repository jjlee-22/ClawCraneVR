using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickControll : MonoBehaviour
{
    public GameObject top_end;
    public GameObject head;
    Quaternion origin_rotation;
    Vector3 ori_pos;
    // Start is called before the first frame update
    void Start()
    {
        origin_rotation = transform.rotation;
        ori_pos = head.transform.position;
        top_end.transform.position = ori_pos;
    }

    // Update is called once per frame
    void Update()
    {
        var grabbable = top_end.GetComponent<OVRGrabbable>();
        if (grabbable.isGrabbed == false)
        {
            transform.rotation = origin_rotation;
            top_end.transform.position = ori_pos;
        }
        else if (grabbable.isGrabbed == true)
        {
            Vector3 V = top_end.transform.position - transform.position;
            Quaternion temp_rot = Quaternion.FromToRotation(Vector3.up, V);
            Vector3 rot = temp_rot.eulerAngles;
            rot.y = 0;
            if (rot.x < 180 && rot.x > 30)
            {
                rot.x = 30f;
            }
            else if (rot.x > 180 && rot.x < 330)
            {
                rot.x = 330f;
            }
            if(rot.z < 180 && rot.z > 30)
            {
                rot.z = 30f;
            }
            else if (rot.z > 180f && rot.z < 330f)
            {
                rot.z = 330f;
            }
            transform.rotation = Quaternion.Euler(rot);
        }
    }
}
