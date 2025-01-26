using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pretzal : MonoBehaviour
{
    public float maxX;
    public bool moveLeft;
    public float moveSpeed;
    public float rotationSpeed;
    public GameObject pretzal;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (moveLeft)
        {
            transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);

            pretzal.transform.Rotate(0, 0, +rotationSpeed * Time.deltaTime);

        }
        else
        {
            transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);

            pretzal.transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);

        }



        if (transform.position.x > maxX || transform.position.x < -maxX)
        {
            this.gameObject.SetActive(false);
        }
    }
}
