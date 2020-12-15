using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class JoyStickInput : MonoBehaviour
{
    public TestSceneNode the_node;
    public float xRange;
    public float zRange;
    private Vector3 xMax;
    private Vector3 zMax;
    float sensitivity = 0.001f;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 node_origin = the_node.NodeOrigin;
        xMax = node_origin + new Vector3(xRange,0,0);
        zMax = node_origin + new Vector3(0,0,zRange);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rot = transform.rotation.eulerAngles;
        Vector3 node_origin = the_node.NodeOrigin;
        float x = 0;
        float z = 0;
        if(6 <= rot.z && rot.z < 31)
        {
            x = -rot.z * sensitivity;
        }
        else if(rot.z >= 330 && rot.z <= 354)
        {
            x = (60 - rot.z + 300) * sensitivity;
        }
        if(6 <= rot.x && rot.x < 31)
        {
            z = rot.x * sensitivity;
        }
        else if(rot.x >= 330 && rot.x <= 354)
        {
            z = -(60 - rot.x + 300) * sensitivity;
        }
        node_origin = node_origin+ new Vector3(x, 0, z);

        if(Math.Abs(node_origin.x) >= Math.Abs(xMax.x)) {
            return;
        }
        if(Math.Abs(node_origin.z) >= Math.Abs(zMax.z)) {
            return;
        }

        the_node.NodeOrigin = node_origin;
    }
}
