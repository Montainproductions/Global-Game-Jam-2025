using UnityEngine;

public class CactusMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float currentSpeed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - currentSpeed * Time.deltaTime);
    }
}
