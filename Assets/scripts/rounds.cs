using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class rounds : MonoBehaviour
{
    public TextMeshProUGUI roundNum;
    public int roundNumIndex = 1;
    public rngSpawn character;

    private void Start()
    {
        character = GetComponent<rngSpawn>();
    }
    public void Update()
    {
        roundNum.text = roundNumIndex.ToString();

        if (character.liveEnemyCount <= 1 )
        {
            roundNumIndex++;             
        }
    }
}
