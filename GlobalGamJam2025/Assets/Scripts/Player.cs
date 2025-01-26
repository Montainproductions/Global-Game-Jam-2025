using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] playerClips;

    public Animator animator;

    [Header("Player Movement")]
    public int currentHP;
    public int maxHP;
    public float maxX;
    public float curX;
    public float moveSpeed;
    public bool inflator;
    public Image blenderImage;
    public List<Sprite> blenderSprites = new List<Sprite>();
    public Image specialBulletImage;
    public TextMeshProUGUI specialBulletText;

    [Header("Shooting")]
    public int damage;
    public int air;
    public float airRateReset;
    public float airRate;
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
        Hotdog,
        Icecream,
    }

    [SerializeField] public GunType currentGun;


    [Header("Cactus")]
    public bool cantDrop;
    public List<GameObject> cactai = new List<GameObject>();
    public GameObject cactusDropPosition;
    public List<GameObject> cactusCache = new List<GameObject>();
    public List<Image> cactusImages = new List<Image>();
    public List<Sprite> cactusSprites = new List<Sprite>();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHP = maxHP;

        /* GameObject damageFX;
         for (int i = 0; i < pooledDamageEffectCount; i++)
         {
             damageFX = Instantiate(damageEffect);
             damageFX.SetActive(false);
             pooledDamageEffects.Add(damageFX);
         }

         */
        GunCheck();

        if (inflator)
        {
            blenderImage.sprite = blenderSprites[1];
        }
        else
        {
            blenderImage.sprite = blenderSprites[0];
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (fireRate > 0)
        {
            fireRate -= Time.deltaTime;
        }

        if (airRate > 0)
        {
            airRate -= Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            Sc_GameManager.Instance.PlayPlayerAudioOneShot(playerClips[5]);
            MoveLeft();
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            Sc_GameManager.Instance.StopPlayerAudio();
            animator.SetBool("strafeLeft", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Sc_GameManager.Instance.PlayPlayerAudioOneShot(playerClips[5]);
            MoveRight();
        }else if(Input.GetKeyUp(KeyCode.D))
        {
            Sc_GameManager.Instance.StopPlayerAudio();
            animator.SetBool("strafeRight", false);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Shoot();
        }else{
            if (fireRate <= 0 && airRate <= 0)
            {
                animator.SetBool("isShooting", false);
            }
        }

        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            animator.SetBool("strafeLeft", false);
            animator.SetBool("strafeRight", false);
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

    public void MoveLeft()
    {
        if (transform.position.x > -maxX)
        {
            curX -= moveSpeed * Time.deltaTime;
            animator.SetBool("strafeLeft", true);
            animator.SetBool("strafeRight", false);
        }
        else
        {
            animator.SetBool("strafeLeft", false);
        }
        transform.position = new Vector3(curX, transform.position.y, transform.position.z);
    }

    public void MoveRight()
    {

        if (transform.position.x < maxX)
        {
            curX += moveSpeed * Time.deltaTime;
            animator.SetBool("strafeRight", true);
            animator.SetBool("strafeLeft", false);
        }
        else
        {
            animator.SetBool("strafeRight", false);
        }
        transform.position = new Vector3(curX, transform.position.y, transform.position.z);
    }

    public void GunCheck()
    {
        switch (currentGun)
        {
            case GunType.Normal:
                fireRateReset = .15f;
                damage = 1;
                break;
            case GunType.Hotdog:
                fireRateReset = .35f;
                specialBulletsRemaining = 20;
                damage = 3;
                break;
            case GunType.Icecream:
                fireRateReset = .25f;
                specialBulletsRemaining = 20;
                damage = 3;
                break;
        }

        if (specialBulletsRemaining > 0)
        {
            specialBulletImage.gameObject.SetActive(true);
            specialBulletText.text = specialBulletsRemaining.ToString();
        }
        else
        {
            specialBulletImage.gameObject.SetActive(false);
            specialBulletText.text = specialBulletsRemaining.ToString();
        }
    }

    public void Shoot()
    {
        if (!inflator)
        {
            if (fireRate <= 0)
            {
                animator.SetBool("isShooting", true);

                Debug.Log("shooting");
                if (currentGun == GunType.Normal)
                {
                    Sc_GameManager.Instance.PlayPlayerAudioOneShot(playerClips[0]);
                }
                else if (currentGun == GunType.Hotdog)
                {
                    Sc_GameManager.Instance.PlayPlayerAudioOneShot(playerClips[1]);
                }
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

                        hit.collider.GetComponent<Sc_Health>().currentHealth -= damage;
                        hit.collider.GetComponent<Sc_Health>().UpdateHealth();

                        Debug.Log(" enemy hit");
                    }

                    if (hit.collider.tag == "pickup")
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

                        hit.collider.GetComponent<PickupHealth>().currentHealth -= damage;
                        hit.collider.GetComponent<PickupHealth>().UpdateHealth();
                    }

                    if (currentGun != GunType.Normal)
                    {
                        Sc_GameManager.Instance.PlayPlayerAudioOneShot(playerClips[1]);
                        if (specialBulletsRemaining > 1)
                        {
                            specialBulletsRemaining -= 1;
                        }else{
                            specialBulletsRemaining = 0;
                            currentGun = GunType.Normal;
                            GunCheck();
                        }

                        specialBulletText.text = specialBulletsRemaining.ToString();
                    }
                }
                fireRate = fireRateReset;
            }
        }else{
            if (airRate <= 0)
            {
                Sc_GameManager.Instance.PlayPlayerAudioOneShot(playerClips[2]);
                animator.SetBool("isShooting", true);

                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, shootingDistance, layerMask))
                {
                    if (hit.collider.tag == "enemy")
                    {
                        hit.collider.GetComponent<Sc_Health>().currentInflation += air;
                        hit.collider.GetComponent<Sc_Health>().UpdateHealth();
                    }
                }
                airRate = airRateReset;
            }
        }
    }

    public void SwapWeapon()
    {
        if (inflator)
        {
            inflator = false;
            blenderImage.sprite = blenderSprites[0];
            if (specialBulletsRemaining > 0)
            {
                specialBulletImage.gameObject.SetActive(true);
                specialBulletText.text = specialBulletsRemaining.ToString();

            }
        }
        else
        {
            inflator = true;
            blenderImage.sprite = blenderSprites[1];
            specialBulletImage.gameObject.SetActive(false);

        }
    }

    public void DropCactus()
    {
        if (!cantDrop)
        {
            if (cactusCache[0] != null)
            {
                Sc_GameManager.Instance.PlayPlayerAudioOneShot(playerClips[3]);
                Instantiate(cactusCache[0], cactusDropPosition.transform.position, Quaternion.identity);

                cactusCache[0] = null;

                for (int i = 0; i < cactusCache.Count - 1; i++)
                {
                    cactusCache[i] = cactusCache[i + 1];
                }
                cactusCache[4] = null;

                CactusCheck();
            }
            else
            {
                Sc_GameManager.Instance.PlayPlayerAudioOneShot(playerClips[4]);
                Debug.Log("no cactus");
            }
        }
        else
        {
            Debug.Log("cant drop here");
        }
    }

    public void CactusCheck()
    {
        for (int i = 0; i < cactusCache.Count; i++)
        {
            if (cactusCache[i] == cactai[0])
            {
                cactusImages[i].sprite = cactusSprites[0];
                cactusImages[i].gameObject.SetActive(true);

            }

            else if (cactusCache[i] == cactai[1])
            {
                cactusImages[i].sprite = cactusSprites[1];
                cactusImages[i].gameObject.SetActive(true);

            }

            else if (cactusCache[i] == null)
            {
                cactusImages[i].gameObject.SetActive(false);

            }
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "cactus")
        {
            cantDrop = true;
        }
        else
        {
            cantDrop = false;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "item_hotdog")
        {
            currentGun = GunType.Hotdog;
            Destroy(other.gameObject);
            GunCheck();

            animator.SetBool("grabItem", true);
            Destroy(other.gameObject);
        }


        if (other.gameObject.tag == "item_cactus0")
        {

            for (int i = 0; i < cactusCache.Count; i++)
            {
                if (cactusCache[i] == null)
                {
                    if (i > 0)
                    {
                        for (int j = cactusCache.Count - 1; j > 0; j--)
                        {
                            cactusCache[j] = cactusCache[j - 1];
                        }
                    }

                    cactusCache[0] = cactai[0];
                    animator.SetBool("grabItem", true);
                    Destroy(other.gameObject);
                    CactusCheck();
                    break;
                }
            }
        }

        if (other.gameObject.tag == "item_cactus1")
        {

            for (int i = 0; i < cactusCache.Count; i++)
            {
                if (cactusCache[i] == null)
                {
                    if (i > 0)
                    {
                        for (int j = cactusCache.Count - 1; j > 0; j--)
                        {
                            cactusCache[j] = cactusCache[j - 1];
                        }
                    }

                    cactusCache[0] = cactai[1];
                    animator.SetBool("grabItem", true);
                    Destroy(other.gameObject);
                    CactusCheck();
                    break;
                }
            }
        }
    }
}