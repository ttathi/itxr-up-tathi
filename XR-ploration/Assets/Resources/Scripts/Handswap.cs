using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Handswap : MonoBehaviour
{

    public GameObject RightHand;
    public GameObject LeftHand;
    public GameObject RightCube;
    public GameObject LeftCube;

    public InputActionReference action;

    private bool isCube = true;


    private void Start() // Start is called before the first frame update
    {

        action.action.Enable();

        action.action.performed += (ctx) =>
        {
            isCube = !isCube;

            if (isCube)
            {
                RightCube.transform.localPosition = new Vector3(0, -0.036f, -0.16f);
                LeftCube.transform.localPosition = new Vector3(0, -0.036f, -0.16f);

                RightHand.transform.localPosition = new Vector3(300, -0.036f, -0.16f);
                LeftHand.transform.localPosition = new Vector3(300, -0.036f, -0.16f);
            }
            else
            {
                RightCube.transform.localPosition = new Vector3(300, -0.036f, -0.16f);
                LeftCube.transform.localPosition = new Vector3(300, -0.036f, -0.16f);

                RightHand.transform.localPosition = new Vector3(0, -0.036f, -0.16f);
                LeftHand.transform.localPosition = new Vector3(0, -0.036f, -0.16f);
            }
        };

    }

    
    private void Update() // Update is called once per frame
    {
        
    }
}
