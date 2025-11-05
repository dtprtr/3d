using System.Collections;
using UnityEngine;

public class rngSpawn : MonoBehaviour
{
    public enemyscriptable theEnemy;
    [HideInInspector] public int xPos;
    [HideInInspector] public int zPos;
    public int totalEnemyCount;
    public int liveEnemyCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
                xPos = Random.Range(-25, 25);
                zPos = Random.Range(-25, 25);
                Instantiate(theEnemy.enemyPrefab, new Vector3(xPos, 0, zPos), Quaternion.identity);

                yield return new WaitForSeconds(0.1f);
            }

            yield return new WaitUntil(() => liveEnemyCount < 1);
            yield return new WaitForSeconds(4f);

            totalEnemyCount = 0;
            liveEnemyCount = 0;
        }
    }
}
