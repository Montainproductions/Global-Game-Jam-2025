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
    public float fireRateReset;
    public float fireRate;
    public int specialBulletsRemaining;
    public RaycastHit hit;
    public LayerMask layerMask;
    public float shootingDistance;

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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
                    GameObject damageDecal = ObjectPool.SharedInstance.GetPooledObject();
                    if (damageDecal != null)
                    {
                        damageDecal.transform.position = hit.point;
                        damageDecal.SetActive(true);
                    }

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
