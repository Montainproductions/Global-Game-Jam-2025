using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotdog : MonoBehaviour
{

    public float rotationSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(-rotationSpeed * Time.deltaTime, 0, 0);
    }

}
