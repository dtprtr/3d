using System.Collections;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;

public class rngSpawn : MonoBehaviour
{
    public enemyscriptable theEnemy;
    [HideInInspector] public int xPos;
    [HideInInspector] public int zPos;
    public int totalEnemyCount;
    public int liveEnemyCount;

    public character_movement character;
  
    void Start()
    {
        
        StartCoroutine(SpawnNewEnemy());

    }

    IEnumerator SpawnNewEnemy()
    {
        while (true)
        {
            while (totalEnemyCount < 5)
            {
                xPos = Random.Range(90, 110);
                zPos = Random.Range(130, 150);
                
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
