using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_GameManager : MonoBehaviour
{
    private int currentRound = 0;
    
    private int basicEnemiesToSpawn = 0, midEnemiesToSpawn = 0, largeEnemiesToSpawn = 0;

    [SerializeField] //5, 15, 65
    private int currentRoundPointValue, basicEnemyPointValue, midEnemyPointValue, largeEnemyPointValue;

    [SerializeField]
    private int designerVal;

    [SerializeField]
    private GameObject baseEnemy;

    [SerializeField]
    private GameObject[] spawnPoint1, spawnPoint2;

    // Start is called before the first frame update
    void Start()
    {
        NewRoundPoints();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewRoundPoints(){
        currentRound++;
        currentRoundPointValue = currentRound * designerVal;
        EnemiesToSpawn();
    }

    public void EnemiesToSpawn(){
        int returnedRange;
        while(currentRoundPointValue > basicEnemyPointValue){
            returnedRange = random.range(0,100);
            if(currentRoundPointValue > largeEnemyPointValue){
                if(returnedRange < 70){
                    basicEnemiesToSpawn++;
                    currentRoundPointValue -= basicEnemyPointValue;
                }else if(returnedRange > 70 && returnedRange < 90){
                    midEnemiesToSpawn++;
                    currentRoundPointValue -= midEnemyPointValue;
                }else{
                    largeEnemiesToSpawn++;
                    currentRoundPointValue -= largeEnemyPointValue;
                }
            }else if(currentRoundPointValue > midEnemyPointValue){
                if(returnedRange < 80){
                    basicEnemiesToSpawn++;
                    currentRoundPointValue -= basicEnemyPointValue;
                }else{
                    midEnemiesToSpawn++;
                    currentRoundPointValue -= midEnemyPointValue;
                }
            }else{
                basicEnemiesToSpawn++;
                currentRoundPointValue -= basicEnemyPointValue;
            }
        }

        Debug.Log(basicEnemiesToSpawn + midEnemiesToSpawn + largeEnemiesToSpawn);
    }

    public void ChooseSide(){
        
    }

}
