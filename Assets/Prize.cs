using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prize : MonoBehaviour
{
    public GameObject PrizePool;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<OVRGrabbable>().isGrabbed == true)
        {
            transform.parent = null;
            GetComponent<Rigidbody>().isKinematic = true;
        }
        else
        {
            if (transform.parent == null)
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = PrizePool.transform;
            }
        }
    }
}
