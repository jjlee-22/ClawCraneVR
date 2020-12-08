using UnityEngine;

public class TheWorld : MonoBehaviour
{
    public SceneNode TheRoot;
    public Camera HeadNodeCam;

    private void Update()
    {
        Matrix4x4 i = Matrix4x4.identity;
        Vector3 tipTransform;
        Vector3 zero = Vector3.zero;
        Vector3 tipVector;

        TheRoot.CompositeXform(ref zero, ref i, out tipTransform, out tipVector);
        Vector3 p1 = tipTransform;
        Vector3 vector3 = tipTransform + 15f * tipVector;

        HeadNodeCam.transform.localPosition = tipTransform + 3f * tipVector;
        HeadNodeCam.transform.LookAt(vector3, Vector3.up);
    }
}
