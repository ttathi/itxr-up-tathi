using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MagnifyingGlass : MonoBehaviour
{

    public Transform mainCameraTransform;
    public Transform glassCameraTransform;
    public Transform screen;



    private void Start() // Start is called before the first frame update
    {
        
    }
    
    private void Update() // Update is called once per frame
    {
        Vector3 dir = (glassCameraTransform.position - mainCameraTransform.position).normalized;
        Vector3 dir2 = (mainCameraTransform.position - new Vector3(-glassCameraTransform.position.x, glassCameraTransform.position.y, glassCameraTransform.position.z)).normalized;

        glassCameraTransform.rotation = Quaternion.LookRotation(dir, transform.up);
        screen.rotation = Quaternion.LookRotation(dir, transform.up);

    }

}
