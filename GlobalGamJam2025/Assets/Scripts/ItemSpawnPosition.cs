using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnPosition : MonoBehaviour
{
    public float maxX;
    public float curX;
    public float moveSpeed;
    public bool moveLeft;

    void Start()
    {

    }

    void Update()
    {
        if (moveLeft)
        {
            if (transform.position.x > -maxX)
            {
                curX -= moveSpeed * Time.deltaTime;
            }
            else
            {
                moveLeft = false;
            }
        }
        else
        {
            if (transform.position.x < maxX)
            {
                curX += moveSpeed * Time.deltaTime;
            }

            else
            {
                moveLeft = true;
            }
        }

        transform.position = new Vector3(curX, transform.position.y, transform.position.z);
    }

}
