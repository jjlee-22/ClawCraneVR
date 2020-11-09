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


        if(isIndexFingerPinching) {
            debugText.text = "True";
            GrabBegin();
        } else {
            debugText.text = "False";
            GrabEnd();
        }
    }
}
