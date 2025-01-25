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
    private Vector3[] spawnPoint1, spawnPoint2;

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
        //currentRoundPointValue = currentRound * designerVal;
        EnemiesToSpawn();
    }

    public void EnemiesToSpawn()
    {
        int totalEnemySpawn;

        AmountOfEnemies();

        totalEnemySpawn = basicEnemiesToSpawn + midEnemiesToSpawn + largeEnemiesToSpawn;

        for (int i = 0; i < totalEnemySpawn; i++)
        {
            ChooseSide();
        }
        Debug.Log(basicEnemiesToSpawn + midEnemiesToSpawn + largeEnemiesToSpawn);
    }

    public void AmountOfEnemies()
    {
        int returnedRange;
        while (currentRoundPointValue > basicEnemyPointValue)
        {
            returnedRange = Random.Range(0, 100);
            if (currentRoundPointValue > largeEnemyPointValue)
            {
                if (returnedRange < 70)
                {
                    basicEnemiesToSpawn++;
                }
                else if (returnedRange > 70 && returnedRange < 90)
                {
                    midEnemiesToSpawn++;
                }
                else
                {
                    largeEnemiesToSpawn++;
                }
            }
            else if (currentRoundPointValue > midEnemyPointValue)
            {
                if (returnedRange < 80)
                {
                    basicEnemiesToSpawn++;
                }
                else
                {
                    midEnemiesToSpawn++;
                }
            }
        }
    }

    IEnumerator ChooseSide()
    {
        int chooseSide, spawnerVal;
        chooseSide = Random.Range(0, 2);
        spawnerVal = Random.Range(0, 3);

        yield return new WaitForSeconds(chooseSide);

        if (chooseSide == 0)
        {
            if (basicEnemiesToSpawn > 0)
            {
                Instantiate(baseEnemy, spawnPoint1[spawnerVal], Quaternion.identity);
                basicEnemiesToSpawn--;
            }
            else if (midEnemiesToSpawn > 0)
            {
                Instantiate(midEnemy, spawnPoint1[spawnerVal], Quaternion.identity);
                midEnemiesToSpawn--;
            }
            else if (largeEnemiesToSpawn > 0)
            {
                Instantiate(largeEnemy, spawnPoint1[spawnerVal], Quaternion.identity);
                largeEnemiesToSpawn--;
            }
        }
        else
        {
            if (basicEnemiesToSpawn > 0)
            {
                Instantiate(baseEnemy, spawnPoint2[spawnerVal], Quaternion.identity);
                basicEnemiesToSpawn--;
            }
            else if (midEnemiesToSpawn > 0)
            {
                Instantiate(midEnemy, spawnPoint2[spawnerVal], Quaternion.identity);
                midEnemiesToSpawn--;
            }
            else if (largeEnemiesToSpawn > 0)
            {
                Instantiate(largeEnemy, spawnPoint2[spawnerVal], Quaternion.identity);
                largeEnemiesToSpawn--;
            }
        }

        yield return null;
    }
}
