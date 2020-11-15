using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;
using UnityEngine.UI;

public class GrabbableBehavior : OVRGrabbable
{
    private Renderer m_color;
    public Material mat;
    public MainController m_controller;
    public Text debugTextisCollided;
    public Text debugTextCollidedObj;
     
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        m_color = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfGrabbed();
    }

    private void OnTriggerEnter(Collider other)
    {
        debugTextisCollided.text = "True";
        debugTextCollidedObj.text = gameObject.name;
        m_controller.FindObject(gameObject);
    }

    void CheckIfGrabbed()
    {
        if (isGrabbed)
        {
            //gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
        else
        {
            //gameObject.GetComponent<Renderer>().material = mat;
        }
    }
}
