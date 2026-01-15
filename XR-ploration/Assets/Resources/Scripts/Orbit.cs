using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{

    private float RotationSpeed = 10;


    private void Start() // Start is called before the first frame update
    {
        
    }

    
    private void Update() // Update is called once per frame
    {
        transform.Rotate(new Vector3(0f, Time.deltaTime * RotationSpeed, 0f));
    }
}
