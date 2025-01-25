using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugEnemySpawn : MonoBehaviour
{

    public GameObject enemy;

    public int spawnPosX;
    public int spawnPosZ;
    public TextMeshProUGUI text;
    public int enemycount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            enemycount += 1;
            Spawn();
            text.text = "Enemy Count = " + enemycount;
        }
    }

    public void Spawn()
    {
        Instantiate(enemy, new Vector3(spawnPosX, transform.position.y, spawnPosZ), Quaternion.identity);

        spawnPosX += 1;

        if (spawnPosX > 20)
        {
            spawnPosX = 0;
            spawnPosZ += 1;

        }
    }
}
