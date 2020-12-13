using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabDetect : MonoBehaviour
{
    public TestNodePrimitive grabpoint;
    public GameObject PrizePool;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 grab_pos = grabpoint.pos;
        transform.position = grab_pos;
        if (OVRInput.GetDown(OVRInput.Button.One) == true)
        {
            Debug.Log("Press Grab");
            foreach(Transform child in PrizePool.transform)
            {
                Vector3 prize_pos = child.position;
                float dist = (prize_pos - transform.position).magnitude;
                if (dist <= 0.5f)
                {
                    child.parent = transform;
                    child.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    break;
                }
            }
        }
    }
}
