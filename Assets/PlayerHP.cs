using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField]
    enemyMoveAttack enemyData;
    [SerializeField]
    public float maxHealth;
    public float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
   
}
