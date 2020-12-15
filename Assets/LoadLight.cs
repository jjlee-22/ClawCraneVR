using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLight : MonoBehaviour {
    public Transform LightPosition;

	void OnPreRender()
    {
        Debug.Log(LightPosition.localPosition);
        Shader.SetGlobalVector("LightPosition", LightPosition.localPosition);
    }
}
