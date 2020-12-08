using System.Collections.Generic;
using UnityEngine;

// Class borrowed and modified from Kelvin's examples

public class SceneNode : MonoBehaviour
{
    protected Matrix4x4 mCombinedParentXform;
    public Vector3 NodeOrigin = Vector3.zero;
    public Vector3 Pivot = Vector3.zero;
    public List<NodePrimitive> PrimitiveList;

    protected void Start()
    {
        InitializeSceneNode();
    }

    private void InitializeSceneNode()
    {
        mCombinedParentXform = Matrix4x4.identity;
    }

    public void CompositeXform(ref Vector3 PivotPos, ref Matrix4x4 parentXform, out Vector3 tipTransfrom, out Vector3 tipVector)
    {
        mCombinedParentXform = CalculateCombinedForm(ref PivotPos, ref parentXform);
        tipTransfrom = mCombinedParentXform.MultiplyPoint(Pivot);
        tipVector = mCombinedParentXform.MultiplyVector(Vector3.up);
        Vector3 v1 = GetVectorFromMatrix(); 

        Matrix4x4 identity = Matrix4x4.identity;

        Vector3 vX = GetvX(mCombinedParentXform.GetColumn(0), v1);
        Vector3 vY = GetvY(mCombinedParentXform.GetColumn(1), v1);
        Vector3 vZ = GetvZ(mCombinedParentXform.GetColumn(2), v1);

        identity.SetColumn(0, vX);
        identity.SetColumn(1, vY);
        identity.SetColumn(2, vZ);

        Quaternion quaternion = Quaternion.LookRotation(vZ, vY);


        foreach (Component child in transform)
        {
            SceneNode cn = child.GetComponent<SceneNode>();
            if (cn != null)
                cn.CompositeXform(ref Pivot, ref mCombinedParentXform, out tipTransfrom, out tipVector);
        }

        foreach (NodePrimitive p in PrimitiveList)
        {
            p.LoadShaderMatrix(ref Pivot, ref mCombinedParentXform);
        }
    }

    private Matrix4x4 CalculateCombinedForm(ref Vector3 PivotPos, ref Matrix4x4 parentXform)
    {
        Matrix4x4 m1 = Matrix4x4.TRS(PivotPos, Quaternion.identity, Vector3.one);
        Matrix4x4 m2 = Matrix4x4.TRS(Pivot, Quaternion.identity, Vector3.one);
        Matrix4x4 m3 = Matrix4x4.TRS(-Pivot, Quaternion.identity, Vector3.one);
        Matrix4x4 m4 = Matrix4x4.TRS(transform.localPosition, transform.localRotation, transform.localScale);
        return parentXform * m1 * m2 * m3 * m4;
    }

    private Vector3 GetVectorFromMatrix()
    {
        Vector3 col1 = mCombinedParentXform.GetColumn(0);
        Vector3 col2 = mCombinedParentXform.GetColumn(1);
        Vector3 col3 = mCombinedParentXform.GetColumn(2);

        return new Vector3(col1.magnitude, col2.magnitude, col3.magnitude);
    }

    private Vector3 GetvX(Vector3 col1, Vector3 v1) => col1 / v1.x;
    private Vector3 GetvY(Vector3 col2, Vector3 v1) => col2 / v1.x;
    private Vector3 GetvZ(Vector3 col3, Vector3 v1) => col3 / v1.x;

}
