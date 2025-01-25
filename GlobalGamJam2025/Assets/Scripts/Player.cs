using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [Header("Player Movement")]
    public float maxX;
    public float curX;
    public float moveSpeed;
    public bool inflator;
    public TextMeshProUGUI debugGunText;

    [Header("Shooting")]
    public int damage;
    public float fireRateReset;
    public float fireRate;
    public int specialBulletsRemaining;
    public RaycastHit hit;
    public LayerMask layerMask;
    public float shootingDistance;

    public List<GameObject> pooledDamageEffects;
    public GameObject damageEffect;
    public int pooledDamageEffectCount;

    public enum GunType
    {
        Normal,
        Hotdog
    }

    [SerializeField] public GunType currentGun;


    [Header("Cactus")]
    public bool cantDrop;
    public GameObject cactusDropPosition;
    public List<GameObject> cactusCache = new List<GameObject>();

    public List<GameObject> pooledCacti;
    public GameObject cactus;
    public int pooledCactiCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        GameObject damageFX;
        for (int i = 0; i < pooledDamageEffectCount; i++)
        {
            damageFX = Instantiate(damageEffect);
            damageFX.SetActive(false);
            pooledDamageEffects.Add(damageFX);
        }

        GameObject cactusClones;
        for (int i = 0; i < pooledCactiCount; i++)
        {
            cactusClones = Instantiate(cactus);
            cactusClones.SetActive(false);
            pooledCacti.Add(cactusClones);
        }


        //DEBUG - Delete Later
        if (inflator)
        {
            debugGunText.text = "inflator";
        }
        else
        {
            debugGunText.text = "bullets";
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (fireRate > 0)
        {
            fireRate -= Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }

        if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            SwapWeapon();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            DropCactus();
        }
    }

    public void GunCheck()
    {
        switch (currentGun)
        {
            case GunType.Normal:
                fireRateReset = .15f;
                break;
            case GunType.Hotdog:
                fireRateReset = .35f;
                break;
        }
    }


    public void MoveLeft()
    {
        if (transform.position.x > -maxX)
        {
            curX -= moveSpeed * Time.deltaTime;
        }

        transform.position = new Vector3(curX, transform.position.y, transform.position.z);
    }

    public void MoveRight()
    {

        if (transform.position.x < maxX)
        {
            curX += moveSpeed * Time.deltaTime;
        }

        transform.position = new Vector3(curX, transform.position.y, transform.position.z);
    }

    public void Shoot()
    {
        if (fireRate <= 0)
        {
            Debug.Log("shooting");
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * shootingDistance, Color.yellow);
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, shootingDistance, layerMask))
            {
                if (hit.collider.tag == "enemy")
                {
                    for (int i = 0; i < pooledDamageEffectCount; i++)
                    {
                        if (!pooledDamageEffects[i].activeInHierarchy)
                        {
                            pooledDamageEffects[i].transform.position = hit.point;
                            pooledDamageEffects[i].SetActive(true);
                            break;
                        }
                    }


                    if (!inflator)
                    {
                        hit.collider.GetComponent<Sc_Health>().currentHealth -= damage;
                    }
                    else
                    {
                        hit.collider.GetComponent<Sc_Health>().currentHealth += damage;
                    }

                    hit.collider.GetComponent<Sc_Health>().UpdateHealth();

                    Debug.Log("hit");
                }
            }
            else
            {
                Debug.Log("no hit");
            }

            if (currentGun != GunType.Normal)
            {
                if (specialBulletsRemaining > 1)
                {
                    specialBulletsRemaining -= 1;
                }
                else
                {
                    specialBulletsRemaining = 0;
                    currentGun = GunType.Normal;
                    GunCheck();
                }
            }

            fireRate = fireRateReset;

        }
    }

    public void SwapWeapon()
    {
        if (inflator)
        {
            inflator = false;
            debugGunText.text = "bullets";
        }
        else
        {
            inflator = true;
            debugGunText.text = "inflator";
        }
    }

    public void DropCactus()
    {
        if (!cantDrop)
        {
            if (cactusCache[0] != null)
            {
                cactusCache[0].transform.position = cactusDropPosition.transform.position;
                cactusCache[0] = null;

                for (int i = 1; i < cactusCache.Count; i++)
                {
                    if (cactusCache[i] != null)
                    {
                        cactusCache[i - 1] = cactusCache[i];
                        cactusCache[i] = null;
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else
            {
                Debug.Log("no cactus");
            }
        }
        else
        {
            Debug.Log("cant drop here");
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "cactus")
        {
            cantDrop = false;
        }
        else
        {
            cantDrop = true;
        }
    }
}
