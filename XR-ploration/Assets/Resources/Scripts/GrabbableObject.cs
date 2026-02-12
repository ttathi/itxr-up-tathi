using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GrabbableObject : MonoBehaviour
{

    private Transform handForm1;
    private Transform handForm2;

    public Rigidbody RB;

    public InputActionReference action;

    private bool doubleRotate = false;

    private void Start() // Start is called before the first frame update
    {
        action.action.Enable();

        action.action.performed += (ctx) =>
        {
            doubleRotate = !doubleRotate;
        };
    }

    
    private void Update() // Update is called once per frame
    {
        if (handForm1 != null && handForm2 == null)
        {
            RB.position = handForm1.position;
            if (doubleRotate) RB.rotation = handForm1.rotation * handForm1.rotation;
            else RB.rotation = handForm1.rotation;
        }
        else if (handForm1 != null && handForm2 != null)
        {
            RB.position = (handForm1.position + handForm2.position) / 2;
            if (doubleRotate) RB.rotation = Quaternion.Slerp(handForm1.rotation, handForm2.rotation, .5f) * Quaternion.Slerp(handForm1.rotation, handForm2.rotation, .5f);
            else RB.rotation = Quaternion.Slerp(handForm1.rotation, handForm2.rotation, .5f);
        }
    }

    public bool getGrabbed(Transform grabber)
    {
        bool answer = false;

        if (handForm1 == null)
        {
            handForm1 = grabber;
            answer = true;
        }
        else if (handForm2 == null)
        {
            handForm2 = grabber;
            answer = true;
        }

        if (handForm1 != null || handForm2 != null) RB.useGravity = false;

        return answer;
    }

    public void getUngrabbed(Transform grabber)
    {
        if (grabber == handForm1) 
        {
            if (handForm2 == null) handForm1 = null;
            else
            {
                handForm1 = handForm2;
                handForm2 = null;
            }
        }
        else if (grabber == handForm2)
        {
            handForm2 = null;
        }
        
        if (handForm1 == null && handForm2 == null) RB.useGravity = true;
    }
}
