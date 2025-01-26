using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotdog : MonoBehaviour
{
    public float currentSpeed;
    public float rotationSpeed;
    public GameObject hotdog;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - currentSpeed * Time.deltaTime);
        hotdog.transform.Rotate(-rotationSpeed * Time.deltaTime, 0, 0);
    }

}
