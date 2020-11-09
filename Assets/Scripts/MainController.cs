using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainController : MonoBehaviour
{
    public Camera MainCamera;   // camera object
    public XformControl m_form; // form control object 
    public WorldController m_worldControl; // world object
    public DropDownMenu m_DropDownMenu; // dropdown object

    private void Update()
    {
        LMBSelect();
    }

    private void FindObject(GameObject g)
    {
        m_form.SetSelectedObject(m_worldControl.SelectObject(g));
    }

    // Object selection using RayCast from camera's perspective
    private void LMBSelect()
    {
        if (!Input.GetMouseButtonDown(0) || EventSystem.current.IsPointerOverGameObject())  return;

        RaycastHit hitInfo = new RaycastHit();

        if (Physics.Raycast(MainCamera.ScreenPointToRay(Input.mousePosition), out hitInfo, float.PositiveInfinity, 1))
        {
            FindObject(hitInfo.transform.gameObject);
        } else {
            this.FindObject(null);
        }
    }
}
