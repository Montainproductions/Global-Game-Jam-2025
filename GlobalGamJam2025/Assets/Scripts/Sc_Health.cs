using UnityEngine;

public class Sc_Health : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;

    private float currentHealth;

    [SerializeField]
    private GameObject gameObject;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void UpdateHealth(float newHealth){
        if(currentHealth + newHealth > maxHealth) {currentHealth = maxHealth; return;}
        
        health += newHealth;

        if(health < 1){
            health = 0;
            Destroy(gameObject);
        }
    }
}
