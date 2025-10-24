using JetBrains.Annotations;
using System;
using UnityEngine;

public class enemyMoveAttack : MonoBehaviour
{
    [SerializeField]
    enemyscriptable enemyData;
    [SerializeField]
    public float currentHealth;
    public GameObject player;
    bulletscript bullet;



    public CharacterController controller;
    void Start()
    {
       currentHealth = enemyData.maxhealth;
        GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

 


        transform.LookAt(player.transform);
        controller.Move(transform.forward * enemyData.speed * Time.deltaTime);

        

       
    }

   public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
