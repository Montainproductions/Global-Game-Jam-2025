using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_GameManager : MonoBehaviour
{
    private int currentRound = 0;

    private int basicEnemiesToSpawn = 0, midEnemiesToSpawn = 0, largeEnemiesToSpawn = 0;

    [SerializeField] //5, 15, 45
    private int currentRoundPointValue, basicEnemyPointValue, midEnemyPointValue, largeEnemyPointValue;

    [SerializeField]
    private int designerVal;

    [SerializeField]
    private GameObject baseEnemy, midEnemy, largeEnemy;

    [SerializeField]
    private Transform[] spawnPoint1, spawnPoint2;

    // Start is called before the first frame update
    void Start()
    {
        NewRoundPoints();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NewRoundPoints()
    {
        currentRound++;

        //***COMMENTED OUT SO SCRIPT WOULD COMPILE***
        currentRoundPointValue = currentRound * designerVal;
        //Debug.Log(currentRoundPointValue);
        StartCoroutine(EnemiesToSpawn());
    }

    IEnumerator EnemiesToSpawn()
    {
        int totalEnemySpawn;

        StartCoroutine(AmountOfEnemies());

        totalEnemySpawn = basicEnemiesToSpawn + midEnemiesToSpawn + largeEnemiesToSpawn;

        for (int i = 0; i < totalEnemySpawn; i++)
        {
            yield return new WaitForSeconds(0.75f);
            //Debug.Log(totalEnemySpawn);
            StartCoroutine(ChooseSide());
        }
        //EnemiesToSpawn();
    }

    IEnumerator AmountOfEnemies()
    {
        int returnedRange;
        while (currentRoundPointValue >= basicEnemyPointValue)
        {
            returnedRange = Random.Range(0, 100);
            //yield return new WaitForSeconds(0.01f);
            if (currentRoundPointValue > largeEnemyPointValue)
            {
                if (returnedRange < 70)
                {
                    basicEnemiesToSpawn++;
                    currentRoundPointValue -= basicEnemyPointValue;
                }
                else if (returnedRange > 70 && returnedRange < 90)
                {
                    midEnemiesToSpawn++;
                    currentRoundPointValue -= midEnemyPointValue;
                }
                else
                {
                    largeEnemiesToSpawn++;
                    currentRoundPointValue -= largeEnemyPointValue;
                }
            }
            else if (currentRoundPointValue > midEnemyPointValue)
            {
                if (returnedRange < 80)
                {
                    basicEnemiesToSpawn++;
                    currentRoundPointValue -= basicEnemyPointValue;
                }
                else
                {
                    midEnemiesToSpawn++;
                    currentRoundPointValue -= midEnemyPointValue;
                }
            }else{
                if (returnedRange < 80)
                {
                    basicEnemiesToSpawn++;
                    currentRoundPointValue -= basicEnemyPointValue;
                }
            }
        }
        yield return null;
    }

    IEnumerator ChooseSide()
    {
        int chooseSide, spawnerVal;
        chooseSide = Random.Range(0, 2);

        //Debug.Log(chooseSide);
        if (chooseSide == 0)
        {
            spawnerVal = Random.Range(0, spawnPoint1.Length);
            //Debug.Log("Hello Area 1");
            if (basicEnemiesToSpawn > 0)
            {
                Instantiate(baseEnemy, spawnPoint1[spawnerVal].position, Quaternion.identity);
                basicEnemiesToSpawn--;
            }
            else if (midEnemiesToSpawn > 0)
            {
                Instantiate(midEnemy, spawnPoint1[spawnerVal].position, Quaternion.identity);
                midEnemiesToSpawn--;
            }
            else if (largeEnemiesToSpawn > 0)
            {
                Instantiate(largeEnemy, spawnPoint1[spawnerVal].position, Quaternion.identity);
                largeEnemiesToSpawn--;
            }
        }
        else
        {
            spawnerVal = Random.Range(0, spawnPoint2.Length);
            //Debug.Log("Hello 2 Area");
            if (basicEnemiesToSpawn > 0)
            {
                Instantiate(baseEnemy, spawnPoint2[spawnerVal].position, Quaternion.identity);
                
                basicEnemiesToSpawn--;
            }
            else if (midEnemiesToSpawn > 0)
            {
                Instantiate(midEnemy, spawnPoint2[spawnerVal].position, Quaternion.identity);
                midEnemiesToSpawn--;
            }
            else if (largeEnemiesToSpawn > 0)
            {
                Instantiate(largeEnemy, spawnPoint2[spawnerVal].position, Quaternion.identity);
                largeEnemiesToSpawn--;
            }
        }

        yield return null;
    }
}
