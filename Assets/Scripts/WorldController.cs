using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Again, thanks to Kelvin's code examples!

public class WorldController : MonoBehaviour
{
    private GameObject m_select;
    private Color originalColor = Color.white;

    // Select and return the raycasted Object
    public GameObject SelectObject(GameObject obj)
    {
        if (obj != null && obj.name == "Quad")
        {
            obj = null;
        }
            
        sObject(obj);
        return m_select;
    }

    private void sObject(GameObject g)
    {
        if (m_select != null)
        {
            m_select.GetComponent<Renderer>().material.color = originalColor;
        }
            
        m_select = g;

        if (m_select == null) return;

        originalColor = g.GetComponent<Renderer>().material.color;
        m_select.GetComponent<Renderer>().material.color = new Color(0.9f, 0.0f, 0.9f, 0.2f);
    }

    public void CreatePrimitive(PrimitiveType type)
    {
        GameObject primitive = GameObject.CreatePrimitive(type);

        if (m_select != null)
        {
            primitive.transform.SetParent(m_select.transform);
            primitive.transform.localPosition = m_select.transform.localPosition + new Vector3(0.1f, 0.1f, 0.1f);

            if (m_select.transform.childCount <= 0) return;

            Transform child = m_select.transform.GetChild(0);
            primitive.GetComponent<Renderer>().material = child.gameObject.GetComponent<Renderer>().material;
        }
        else
        {
            primitive.GetComponent<Renderer>().material.color = Color.black;
            primitive.transform.localPosition = Vector3.one;
        }
    }
}
