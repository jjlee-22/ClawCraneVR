using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTrackingGrabber : OVRGrabber 
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start(); 
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        CheckIndexPinch();

    }
    void CheckIndexPinch()
    {
        var hand = GetComponent<OVRHand>();
        bool isIndexFingerPinching = hand.GetFingerIsPinching(OVRHand.HandFinger.Index);

        if(isIndexFingerPinching && !m_grabbedObj && m_grabCandidates.Count > 0) {
            //debugText.text = m_grabbedObj.gameObject.name;
            debugText.text = "True";
            GrabBegin();
        } 
        else if(!isIndexFingerPinching && m_grabbedObj) {
            //debugText.text = m_grabbedObj.gameObject.name;
            debugText.text = "False";
            GrabEnd();
        }
        
    }
}
