using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.Controls.AxisControl;

public class Breakout : MonoBehaviour
{

    private bool inRoom = true;

    public InputActionReference action;


    private void Start() // Start is called before the first frame update
    {

        action.action.Enable();

        action.action.performed += (ctx) =>
        {

            inRoom = !inRoom;

            if (inRoom) transform.position = new Vector3(0, 0, 0);
            else transform.position = new Vector3(-20, 5, -35);

        };
    }

    
    private void Update() // Update is called once per frame
    {
        
    }
}
