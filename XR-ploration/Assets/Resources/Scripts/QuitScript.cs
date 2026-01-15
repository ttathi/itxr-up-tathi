using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.OpenXR.Input;

public class QuitScript : MonoBehaviour
{

    public InputActionReference action;


    private void Start() // Start is called before the first frame update
    {
        action.action.Enable();

        action.action.performed += (ctx) =>
        {

            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif

        };
    }

    private void Update() // Update is called once per frame
    {
        
    }
}
