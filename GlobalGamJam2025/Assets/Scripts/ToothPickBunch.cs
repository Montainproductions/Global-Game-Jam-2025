using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ToothPickBunch : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float moveSpeed;
    public float rotationSpeed;
    public GameObject bundle;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);

        bundle.transform.Rotate(0, rotationSpeed * Time.deltaTime , 0);
    }
}
