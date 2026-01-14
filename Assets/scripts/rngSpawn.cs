using System;
using System.Collections;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;
using static UnityEngine.UI.Image;

public class rngSpawn : MonoBehaviour
{
    public enemyscriptable theEnemy;
    [HideInInspector] public float xPos;
    [HideInInspector] public float zPos;
    public int totalEnemyCount;
    public int liveEnemyCount;
    public float rand = 15f;
    public float saftyRadius = 5f;

    public character_movement character;
    
  
    void Start()
    {
        
        StartCoroutine(SpawnNewEnemy());
        character = FindFirstObjectByType<character_movement>();
    }
    
    IEnumerator SpawnNewEnemy()
    {
        while (true)
        {
            
            while (totalEnemyCount < 5)
            {
                xPos = character.transform.position.x + UnityEngine.Random.Range(-rand, rand);
                zPos = character.transform.position.z + UnityEngine.Random.Range(-rand, rand);

                while (xPos <= saftyRadius || zPos <= saftyRadius)
                {
                    xPos = character.transform.position.x + UnityEngine.Random.Range(-rand, rand);
                    zPos = character.transform.position.z + UnityEngine.Random.Range(-rand, rand);
                }

                Debug.Log("\nx = " + (xPos - character.transform.position.x) + " y = " + (zPos - character.transform.position.z));

                Instantiate(theEnemy.enemyPrefab, new Vector3(xPos, 0, zPos), Quaternion.identity);

                yield return new WaitForSeconds(0.1f);
            }

            yield return new WaitUntil(() => liveEnemyCount < 1);
            yield return new WaitForSeconds(5f);

            totalEnemyCount = 0;
            liveEnemyCount = 0;
        }
    }
}
