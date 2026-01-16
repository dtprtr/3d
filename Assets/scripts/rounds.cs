using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class rounds : MonoBehaviour
{
    public TextMeshProUGUI roundNum;
    public int roundNumIndex = 1;
    public rngSpawn spawner;

    private void Start()
    {
        spawner = FindFirstObjectByType<rngSpawn>();
    }
    public void Update()
    {
        roundNum.text = roundNumIndex.ToString("round:" + roundNumIndex);
        
       nextRound();
    }
    public void nextRound()
    {
       if(spawner.spawntime < 1f)
       {
            WaitUntil wait = new WaitUntil(() => spawner.liveEnemyCount < 1);
            while (wait.keepWaiting == false)
            {
                roundNumIndex++;

                spawner.amountOfEnemies += 2;
            }

        }

    }
}
