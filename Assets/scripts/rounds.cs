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
        
       
    }
    public void nextRound()
    {
       if(spawner.spawntime < 1f)
       {
           roundNumIndex++;
            
       }

    }
}
