using UnityEngine;

public class Sc_Health : MonoBehaviour
{
    public float startingHealth;
    public float maxHealth;
    public float currentHealth;

    void Start()
    {
        currentHealth = startingHealth;
    }

    public void UpdateHealth(){
       
        if(currentHealth < 1){
            currentHealth = 0;
            Destroy(this.gameObject);

            //death animation
        }

        if (currentHealth >= maxHealth)
        {
            //inflate
        }
    }
}
