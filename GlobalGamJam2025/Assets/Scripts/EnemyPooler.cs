using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPooler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [Header("Enemies")]
    public GameObject smallEnemy;
    public GameObject medEnemy;
    public GameObject bigEnemy;
    public int smallEnemyCount;
    public int medEnemyCount;
    public int bigEnemyCount;
    public List<GameObject> pooledSmall;
    public List<GameObject> pooledMed;
    public List<GameObject> pooledBig;

    [Header("Pickups")]
    public GameObject hotdog;
    public GameObject pretzal;
    public GameObject pickBundle;
    public GameObject cactusBubble0;
    public GameObject cactusBubble1;

    public int hotdogCount;
    public int pretzalCount;
    public int pickBundleCount;
    public int cactusBubble0Count;
    public int cactusBubble1Count;

    public List<GameObject> pooledHotdog;
    public List<GameObject> pooledPretzal;
    public List<GameObject> pooledPickBundle;
    public List<GameObject> pooledCactusBubble0;
    public List<GameObject> pooledCactusBubble1;




    void Start()
    {
        GameObject smallBubble;
        for (int i = 0; i < smallEnemyCount; i++)
        {
            smallBubble = Instantiate(smallEnemy);
            smallBubble.SetActive(false);
            pooledSmall.Add(smallBubble);
        }

        GameObject mediumBubble;
        for (int i = 0; i < smallEnemyCount; i++)
        {
            mediumBubble = Instantiate(medEnemy);
            mediumBubble.SetActive(false);
            pooledMed.Add(mediumBubble);
        }

        GameObject largeBubble;
        for (int i = 0; i < smallEnemyCount; i++)
        {
            largeBubble = Instantiate(bigEnemy);
            largeBubble.SetActive(false);
            pooledBig.Add(largeBubble);
        }

       /* GameObject hotdogTarget;
        for (int i = 0; i < smallEnemyCount; i++)
        {
            hotdogTarget = Instantiate(hotdog);
            hotdogTarget.SetActive(false);
            pooledHotdog.Add(hotdogTarget);
        }

        GameObject pretzalTarget;
        for (int i = 0; i < smallEnemyCount; i++)
        {
            pretzalTarget = Instantiate(pretzal);
            pretzalTarget.SetActive(false);
            pooledPretzal.Add(pretzalTarget);
        }

        GameObject pickBundleTarget;
        for (int i = 0; i < smallEnemyCount; i++)
        {
            pickBundleTarget = Instantiate(pickBundle);
            pickBundleTarget.SetActive(false);
            pooledPickBundle.Add(pickBundleTarget);
        }

        GameObject cactus0Target;
        for (int i = 0; i < smallEnemyCount; i++)
        {
            cactus0Target = Instantiate(cactusBubble0);
            cactus0Target.SetActive(false);
            pooledCactusBubble0.Add(cactus0Target);
        }

        GameObject cactus02Target;
        for (int i = 0; i < smallEnemyCount; i++)
        {
            cactus02Target = Instantiate(cactusBubble1);
            cactus02Target.SetActive(false);
            pooledCactusBubble1.Add(cactus02Target);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
