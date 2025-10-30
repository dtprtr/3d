using System.Collections;
using UnityEngine;

public class rngSpawn : MonoBehaviour
{

    public GameObject theEnemy;
    [HideInInspector] public int xPos;
    [HideInInspector] public int zPos;
    public int enemyCount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       StartCoroutine(enemyDrop());
    }
    IEnumerator enemyDrop()
    {
        while (enemyCount < 5)
        {
            xPos = Random.Range(-25, 25);
            zPos = Random.Range(-25, 25);
            Instantiate(theEnemy, new Vector3(xPos, 0, zPos), Quaternion.identity);
            enemyCount++;
            yield return new WaitForSeconds(1);
        }
    }
    // Update is called once per frame
    void Update()
    {
        //vfx here
    }
}
