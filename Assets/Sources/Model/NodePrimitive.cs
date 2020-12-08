using UnityEngine;

public class NodePrimitive : MonoBehaviour
{
    public Color MyColor = new Color(0.1f, 0.1f, 0.2f, 1f);
    public Vector3 Pivot;
    public Vector3 RotateAxis = Vector3.up;
    public float range = 180f;
    public float speed = 40f;
    private int mdir = 1;
    private float m_angle;
    public bool isRotating;

    private void Update()
    {
        if (!isRotating)
            return;
        if (Mathf.Abs(m_angle) > range)
            mdir *= -1;
        float a = speed * Time.fixedDeltaTime * mdir;
        m_angle += a;
        transform.localRotation = Quaternion.AngleAxis(a, RotateAxis) * transform.localRotation;
    }

    public void LoadShaderMatrix(ref Vector3 pivot, ref Matrix4x4 m)
    {
        Matrix4x4 m1 = Matrix4x4.TRS(pivot, Quaternion.identity, Vector3.one);
        Matrix4x4 m2 = Matrix4x4.TRS(Pivot, Quaternion.identity, Vector3.one);
        Matrix4x4 m3 = Matrix4x4.TRS(-Pivot, Quaternion.identity, Vector3.one);
        Matrix4x4 m4 = Matrix4x4.TRS(transform.localPosition, transform.localRotation, transform.localScale);

        Matrix4x4 matrix = m * m1 * m2 * m4 * m3;

        GetComponent<Renderer>().material.SetMatrix("MyTRSMatrix", matrix);
        GetComponent<Renderer>().material.SetColor("MyColor", MyColor);
    }
}
