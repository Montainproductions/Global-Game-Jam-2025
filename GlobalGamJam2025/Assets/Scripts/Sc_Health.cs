using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Sc_Health : MonoBehaviour
{
    public Animator animator;
    public float currentSpeed;
    public float minZ;
    public float deathCounter;
    public float deathReset;

    public float startingHealth;
    public float currentHealth;

    public float currentInflation;
    public float maxInflation;

    public Canvas enemyCanvas;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI inflationText;

    public bool dead;

 void Start()
    {
        dead = false;
        animator.SetBool("isDead", false);
        deathCounter = deathReset;
        currentHealth = startingHealth;
        UpdateHealth();
    }

    private void Update()
    {
        if (currentHealth > 0)
        {
            if (transform.position.z > minZ)
            {
                animator.SetBool("isWalking", true);
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - currentSpeed * Time.deltaTime);
            }
            else
            {
                animator.SetBool("isWalking", false);
                animator.SetBool("isAttacking", true);
            }
        }
        else
        {
            if (dead)
            {
                if (deathCounter > 0)
                {
                    animator.SetBool("isDead", true);
                    deathCounter -= Time.deltaTime;
                }
                else
                {
                    this.gameObject.SetActive(false);
                }
            }
        }

        
    }

    public void UpdateHealth(){

        if (!dead)
        {
            if (currentHealth < 1)
            {
                currentHealth = 0;
                animator.SetBool("isWalking", false);
                animator.SetBool("isAttacking", false);
                animator.SetBool("isDead", true);
                dead = true;
            }

            if (currentInflation >= maxInflation)
            {
                //inflate
            }

            healthText.text = currentHealth + "/" + startingHealth;
            inflationText.text = currentInflation + "/" + maxInflation;
        }
    }
}
