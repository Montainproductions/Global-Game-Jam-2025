using UnityEngine;

public class Sc_Health : MonoBehaviour
{
    [SerializeField]
    private float health;

    [SerializeField]
    private GameObject gameObject;

    public void UpdateHealth(float newHealth){
        health += newHealth;

        if(health <= 1){
            health = 0;
            Destroy(gameObject);
        }
    }
}
