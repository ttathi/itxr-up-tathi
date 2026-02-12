using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandGrab : MonoBehaviour
{

    public InputActionReference action;

    private Transform itemToGrab;

    private bool isGrabbing = false;

    
    private void Start() // Start is called before the first frame update
    {
        action.action.Enable();

        action.action.performed += (ctx) =>
        {
            if (itemToGrab != null)
            {
                if (!isGrabbing)
                {
                    if (itemToGrab.GetComponent<GrabbableObject>().getGrabbed(transform)) isGrabbing = true;
                }
                else
                {
                    itemToGrab.GetComponent<GrabbableObject>().getUngrabbed(transform);
                    isGrabbing = false;
                }
            }

        };
    }

    
    private void Update() // Update is called once per frame
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Grabbable" && !isGrabbing) itemToGrab = other.transform;
    }

    private void OnTriggerExit(Collider other)
    {
        if (itemToGrab == other.transform && !isGrabbing) itemToGrab = null;
    }
}
