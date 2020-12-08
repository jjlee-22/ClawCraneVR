using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using OculusSampleFramework;

public class HandTrackingGrabber : OVRGrabber
{

    private OVRHand m_hand;
    public Text debugTextisPinching;
    public Text debugTextisGrabbing;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        m_hand = GetComponent<OVRHand>();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        CheckIndexPinch();

    }
    void CheckIndexPinch()
    {
        bool isIndexFingerPinching = m_hand.GetFingerIsPinching(OVRHand.HandFinger.Index);

        if (isIndexFingerPinching)
        {
            debugTextisPinching.text = "True";
        }
        else { debugTextisPinching.text = "False"; }

        if (isIndexFingerPinching && !m_grabbedObj && m_grabCandidates.Count > 0)
        {
            //debugText.text = m_grabbedObj.gameObject.name;
            debugTextisGrabbing.text = "True";
            GrabBegin();
        }
        else if (!isIndexFingerPinching && m_grabbedObj)
        {
            //debugText.text = m_grabbedObj.gameObject.name;
            debugTextisGrabbing.text = "False";
            GrabEnd();
        }

    }
}
