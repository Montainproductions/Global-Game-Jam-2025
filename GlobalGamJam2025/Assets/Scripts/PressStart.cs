using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class pressStart : MonoBehaviour
{

    public Canvas titleCanvas;
    public Image popUpAdd;
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
        if (adGone == false && adTimer > 0)
        {
            adTimer -= Time.deltaTime;
        }
        else
        {
            adImage.gameObject.SetActive(true);

            if (Input.GetKey(KeyCode.Space))
            {
                if (!adGone)
                {
                    adGone = true;
                    adImage.gameObject.SetActive(false);
                }
                else
                {
                    Debug.Log(" start");
                    //startgame
                }
            }
        }


    }
}
