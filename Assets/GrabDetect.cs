using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;

public class GrabDetect : MonoBehaviour
{
    public TestNodePrimitive grabpoint;
    public GameObject PrizePool;
    public GameObject leftFinger;
    public GameObject rightFinger;
    bool grab_complete;
    bool is_grabbing;
    bool is_releasing;
    bool buttonPressed;
    // Start is called before the first frame update
    void Start()
    {
        grab_complete = false;
        is_grabbing = false;
        is_releasing = false;
    }

    public void GrabPrize(InteractableStateArgs obj)
    {
        if (obj.NewInteractableState == InteractableState.ActionState)
        {
            buttonPressed = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 grab_pos = grabpoint.pos;
        transform.position = grab_pos;
        if (OVRInput.GetDown(OVRInput.Button.One) == true && is_releasing==false)
        {
            is_grabbing = true;
            /*foreach(Transform child in PrizePool.transform)
            {
                Vector3 prize_pos = child.position;
                float dist = (prize_pos - transform.position).magnitude;
                if (dist <= 0.5f)
                {
                    child.parent = transform;
                    child.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    break;
                }
            }*/
        }

        bool left_complete = false;
        bool right_complete = false;
        Vector3 left_rot = leftFinger.transform.localRotation.eulerAngles;
        Vector3 right_rot = rightFinger.transform.localRotation.eulerAngles;
        if (is_grabbing == true) // grabbing process
        {
            if(left_rot.z > 341 || left_rot.z < 11)
            {
                left_rot -= new Vector3(0, 0, 20) * Time.deltaTime;
                leftFinger.transform.localRotation = Quaternion.Euler(left_rot);
            }
            else
            {
                left_complete = true;
            }
            if(right_rot.z > 341 || right_rot.z < 11)
            {
                right_rot -= new Vector3(0, 0, 20) * Time.deltaTime;
                rightFinger.transform.localRotation = Quaternion.Euler(right_rot);
            }
            else
            {
                right_complete = true;
            }
            if(left_complete == true && right_complete == true) //grabbing complete
            {
                Debug.Log("Grab Complete");
                is_grabbing = false;
                grab_complete = true;
            }
        }
        else if (is_releasing == true)
        {
            if (left_rot.z >= 340 || left_rot.z <= 10)
            {
                left_rot += new Vector3(0, 0, 20) * Time.deltaTime;
                leftFinger.transform.localRotation = Quaternion.Euler(left_rot);
            }
            else
            {
                left_complete = true;
            }
            if (right_rot.z >= 340 || right_rot.z <= 10)
            {
                right_rot += new Vector3(0, 0, 20) * Time.deltaTime;
                rightFinger.transform.localRotation = Quaternion.Euler(right_rot);
            }
            else
            {
                right_complete = true;
            }
            if (left_complete == true && right_complete == true) //releasing complete
            {
                is_releasing = false;
                is_grabbing = false;
                grab_complete = false;
            }
        }

        if (grab_complete == true && is_grabbing == false && is_releasing == false && transform.childCount==0) //After grabbing is complete, check if an object is grabbed
        {
            Debug.Log("Check if grabbed");
            bool has_grab = false;
            foreach (Transform child in PrizePool.transform)
            {
                Vector3 prize_pos = child.position;
                float dist = (prize_pos - transform.position).magnitude;
                Vector3 s = child.localScale;
                if (dist <= s.x -0.1f)
                {
                    Debug.Log("Grabbed something");
                    has_grab = true;
                    child.parent = transform;
                    child.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    break;
                }
            }
            if (has_grab == false)
            {
                Debug.Log("No grab");
                is_releasing = true;
                grab_complete = false;
            }
        }
    }
}
