using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.OpenXR.Input;

public class Lightswitch : MonoBehaviour
{

    private Light lamp;
    public InputActionReference action;

    //private bool IsOn = true;
    private int LightColor = 0;


    private void Start() // Start is called before the first frame update
    {
        lamp = GetComponent<Light>();

        action.action.Enable();

        action.action.performed += (ctx) =>
        {

            if (LightColor == 0)
            {
                lamp.color = new Color(1, 0, 0);
                LightColor = 1;
            }
            else if (LightColor == 1)
            {
                lamp.color = new Color(0, 1, 0);
                LightColor = 2;
            }
            else if (LightColor == 2)
            {
                lamp.color = new Color(0, 0, 1);
                LightColor = 3;
            }
            else
            {
                lamp.color = new Color(1, 1, 1);
                LightColor = 0;
            }

        };
    }

    private void Update() // Update is called once per frame
    {
        
    }
}
