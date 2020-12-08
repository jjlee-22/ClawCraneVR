using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;

public class SelectContoller : ButtonController
{
    public XformControl m_form;
    public WorldController m_worldControl;
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }

    private void FindObject(GameObject g)
    {
        m_form.SetSelectedObject(m_worldControl.SelectObject(g));
    }

    public void SelectObject(InteractableStateArgs obj)
    {
        if (obj.NewInteractableState == InteractableState.ActionState)
        {
            FindObject(gameObject);
        }
    }
}
