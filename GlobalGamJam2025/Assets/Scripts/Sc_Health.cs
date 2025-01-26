using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Sc_Health : MonoBehaviour
{
    public bool small;
    public bool medium;
    public bool big;
    public Animator animator;
    public float debuffTimer;
    public float speedModifier;
    public float currentSpeed;
    public float minZ;
    public float deathCounter;
    public float deathReset;

    public Player player;
    public float timeToDamage;
    public float timeToDamageReset;

    public float startingHealth;
    public float currentHealth;

    public float currentInflation;
    public float maxInflation;

    public Canvas enemyCanvas;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI inflationText;
    public EnemyWaveSpawner enemyWaveSpawner;

    public bool dead;

    private void OnEnable()
    {
        this.GetComponent<BoxCollider>().enabled = true;
        animator.speed = 1;
        timeToDamage = timeToDamageReset;
        dead = false;
        animator.SetBool("isDead", false);
        deathCounter = deathReset;
        currentHealth = startingHealth;
        currentInflation = 0;
        UpdateHealth();
    }

    void Start()
    {

    }

    private void Update()
    {
        if (debuffTimer > 0)
        {
            debuffTimer -= Time.deltaTime;
        }
        else
        {
            speedModifier = 1;
        }

        if (currentHealth > 0)
        {
            if (transform.position.z > minZ)
            {
                animator.SetBool("isWalking", true);
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - currentSpeed * speedModifier * Time.deltaTime);
            }
            else
            {
                if (timeToDamage > 0)
                {
                    timeToDamage -= Time.deltaTime;
                }
                else
                {
                    AttackPlayer();
                }

                animator.SetBool("isWalking", false);

                if (big)
                {
                    animator.SetBool("isAttacking", true);
                }
                else
                {
                    animator.speed = 2;
                }
            }
        }
        else
        {
            if (dead)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                if (deathCounter > 0)
                {
                    deathCounter -= Time.deltaTime;
                }
                else
                {
                    enemyWaveSpawner.currentKills += 1;
                    this.gameObject.SetActive(false);
                }
            }
        }


    }

    public void AttackPlayer()
    {
        player.currentHP -= 1;
        timeToDamage = timeToDamageReset;
    }

    public void UpdateHealth()
    {

        if (!dead)
        {
            if (currentHealth < 1)
            {
                currentHealth = 0;
                animator.SetBool("isWalking", false);
                if (big)
                {
                    animator.SetBool("isAttacking", false);
                }
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
