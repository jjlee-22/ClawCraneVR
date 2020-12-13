using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNodePrimitive : MonoBehaviour
{
    public Color MyColor = new Color(0.1f, 0.1f, 0.2f, 1.0f);
    public Vector3 Pivot;
    public Matrix4x4 matrix;
    public Vector3 pos;
    public bool debug_pos = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadShaderMatrix(ref Matrix4x4 nodeMatrix)
    {
        Matrix4x4 p = Matrix4x4.TRS(Pivot, Quaternion.identity, Vector3.one);
        Matrix4x4 invp = Matrix4x4.TRS(-Pivot, Quaternion.identity, Vector3.one);
        Matrix4x4 trs = Matrix4x4.TRS(transform.localPosition, transform.localRotation, transform.localScale);
        Matrix4x4 m = nodeMatrix * p * trs * invp;
        matrix = m;
        pos = matrix.GetColumn(3);
        if (debug_pos == true)
        {
            Debug.Log(pos);
        }
        GetComponent<Renderer>().material.SetMatrix("MyXformMat", m);
        GetComponent<Renderer>().material.SetColor("MyColor", MyColor);
    }
}
