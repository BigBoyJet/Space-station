using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class RotateAround : MonoBehaviour
{
    public Transform Target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    
    { }
       

    // Update is called once per frame
    void Update()
    {
            transform.RotateAround(Target.position, Vector3.left, 20 * Time.deltaTime);
        
    }
}
