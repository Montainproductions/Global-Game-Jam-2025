using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveSpawner : MonoBehaviour
{

    public EnemyPooler enemyPooler;
    public GameObject littleSpawner;
    public GameObject mediumSpawner;
    public GameObject bigSpawner;
    public float lSpawnTimer;
    public float lSpawnReset;
    public float mSpawnTimer;
    public float mSpawnReset;
    public float bSpawnTimer;
    public float bSpawnReset;

    public int lCount;
    public int mCount;
    public int bCount;

    public int currentKills;
    public int maxKills;

    public enum WaveType
    {
        wave0,
        wave1,
        wave2
    }

    [SerializeField] public WaveType currentWave;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetWave();
    }

    public void SetWave()
    {
        switch (currentWave)
        {
            case WaveType.wave0:
                lSpawnReset = .5f;
                mSpawnReset = 1f;
                bSpawnReset = 5f;

                lCount = 20;
                mCount = 5;
                bCount = 1;
                break;

            case WaveType.wave1:
                lSpawnReset = .35f;
                mSpawnReset = .5f;
                bSpawnReset = 2.5f;

                lCount = 40;
                mCount = 15;
                bCount = 2;
                break;

            case WaveType.wave2:
                lSpawnReset = .25f;
                mSpawnReset = 1.5f;
                bSpawnReset = 1.5f;

                lCount = 100;
                mCount = 35;
                bCount = 5;
                break;

        }

        lSpawnTimer = lSpawnReset;
        mSpawnTimer = mSpawnReset;
        bSpawnTimer = bSpawnReset;

        currentKills = 0;
        maxKills = lCount + mCount + bCount;
    }

    // Update is called once per frame
    void Update()
    {

        if (currentKills == maxKills)
        {
            switch (currentWave)
            {
                case WaveType.wave0:
                    currentWave = WaveType.wave1;
                    break;

                case WaveType.wave1:
                    currentWave = WaveType.wave2;
                    break;

                case WaveType.wave2:
                    currentWave = WaveType.wave0;
                    break;
            }

            SetWave();
        }

        if (lCount > 0)
        {
            if (lSpawnTimer > 0)
            {
                lSpawnTimer -= Time.deltaTime;
            }
            else
            {
                for (int i = 0; i < enemyPooler.smallEnemyCount; i++)
                {
                    if (!enemyPooler.pooledSmall[i].activeInHierarchy)
                    {
                        enemyPooler.pooledSmall[i].transform.position = littleSpawner.transform.position;
                        enemyPooler.pooledSmall[i].SetActive(true);
                        break;
                    }
                }

                lCount -= 1;
                lSpawnTimer = lSpawnReset;
            }
        }


        if (mCount > 0)
        {
            if (mSpawnTimer > 0)
            {
                mSpawnTimer -= Time.deltaTime;
            }
            else
            {
                for (int i = 0; i < enemyPooler.medEnemyCount; i++)
                {
                    if (!enemyPooler.pooledMed[i].activeInHierarchy)
                    {
                        enemyPooler.pooledMed[i].transform.position = mediumSpawner.transform.position;
                        enemyPooler.pooledMed[i].SetActive(true);
                        break;
                    }
                }

                mCount -= 1;
                mSpawnTimer = mSpawnReset;
            }
        }

        if (bCount > 0)
        {
            if (bSpawnTimer > 0)
            {
                bSpawnTimer -= Time.deltaTime;
            }
            else
            {
                for (int i = 0; i < enemyPooler.bigEnemyCount; i++)
                {
                    if (!enemyPooler.pooledBig[i].activeInHierarchy)
                    {
                        enemyPooler.pooledBig[i].transform.position = bigSpawner.transform.position;
                        enemyPooler.pooledBig[i].SetActive(true);
                        break;
                    }
                }

                bCount -= 1;
                bSpawnTimer = bSpawnReset;
            }
        }
    }

}
