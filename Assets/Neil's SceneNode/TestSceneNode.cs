using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSceneNode : MonoBehaviour
{
    protected Matrix4x4 mCombinedParentXform;
    protected Vector3 original_position;
    protected Quaternion original_rotation;
    protected Vector3 original_scale;

    public Vector3 NodeOrigin = Vector3.zero;
    public List<TestNodePrimitive> PrimitiveList;
    // Start is called before the first frame update
    void Start()
    {
        InitializeSceneNode();
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void InitializeSceneNode()
    {
        original_position = transform.localPosition;
        original_rotation = transform.localRotation;
        original_scale = transform.localScale;
        mCombinedParentXform = Matrix4x4.identity;
    }

    // This must be called _BEFORE_ each draw!! 
    public void CompositeXform(ref Matrix4x4 parentXform)
    {
        Matrix4x4 orgT = Matrix4x4.Translate(NodeOrigin);
        Matrix4x4 trs = Matrix4x4.TRS(transform.localPosition, transform.localRotation, transform.localScale);

        mCombinedParentXform = parentXform * orgT * trs;

        // propagate to all children
        foreach (Transform child in transform)
        {
            TestSceneNode cn = child.GetComponent<TestSceneNode>();
            if (cn != null)
            {
                cn.CompositeXform(ref mCombinedParentXform);
            }
        }

        // disenminate to primitives
        foreach (TestNodePrimitive p in PrimitiveList)
        {
            p.LoadShaderMatrix(ref mCombinedParentXform);
        }

    }

    public void ResetTransform()
    {
        transform.localPosition = original_position;
        transform.localRotation = original_rotation;
        transform.localScale = original_scale;
        foreach (Transform child in transform)
        {
            TestSceneNode cn = child.GetComponent<TestSceneNode>();
            if (cn != null)
            {
                cn.ResetTransform();
            }
        }
    }

    public Matrix4x4 getParentXform()
    {
        return mCombinedParentXform;
    }
}
