using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using OculusSampleFramework;

public class MainController : MonoBehaviour
{
    public XformControl m_form; // form control object 
    public WorldController m_worldControl; // world object
    public DropDownMenu m_DropDownMenu; // dropdown object

    private void Update()
    {
    }

    public void FindObject(GameObject g)
    {
        m_form.SetSelectedObject(m_worldControl.SelectObject(g));
    }

    // Object selection using RayCast from camera's perspective
    
}
