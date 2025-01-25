using UnityEngine;

public class Sc_Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private Transform transformItem;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transformItem.position = transformItem.position + new Vector3(0,0, speed * Time.deltaTime);
    }
}
