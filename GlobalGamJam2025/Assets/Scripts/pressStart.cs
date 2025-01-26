using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class pressStart : MonoBehaviour
{
    public bool adUp;
    public bool adGone;
    public float adTimer;
    public Image adImage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        adGone = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!adUp && adTimer > 0)
        {
            adTimer -= Time.deltaTime;
        }
        else
        {
            adUp = true;
        }

        if (adUp && !adGone)
        {
            adImage.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                adGone = true;
            }
        }
        else
        {
            adImage.gameObject.SetActive(false);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("Delaney-Scene");
            }
        }
    }
}

