using JetBrains.Annotations;
using System;
using Unity.VisualScripting;
using UnityEngine;

public class enemyMoveAttack : MonoBehaviour
{
    public enemyscriptable enemyData;
    
    public float currentHealth;
    private GameObject player;
    

    public float timeBetweenAttacks;
    public float radius;
    private float timer;


    private bool isPlayerInRange;


    private character_movement playermove;
    public CharacterController controller;

    private void Awake()
    {
        FindFirstObjectByType<rngSpawn>().liveEnemyCount++;
        FindFirstObjectByType<rngSpawn>().totalEnemyCount++;
        
        player = GameObject.FindWithTag("Player");
    }

    private void OnDestroy()
    {
        if (player != null)
        FindFirstObjectByType<rngSpawn>().liveEnemyCount--;
        Debug.Log("enemy die");

        playermove.currScore++;
    }

    void Start()
    {
        currentHealth = enemyData.maxhealth;
        playermove = FindFirstObjectByType<character_movement>();
        GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

      
        if (player != null) 
        {
            transform.LookAt(player.transform);
            controller.Move(transform.forward * enemyData.speed * Time.deltaTime);
        }

        hurtBox();
    }

    public void hurtBox()
    {
        timer += Time.deltaTime;
        if(player == null)
        {
            return;
        }
        if (Vector3.Distance(transform.position,player.transform.position)<radius) 
        {
            if (!isPlayerInRange)
            {
                DealDamage();
                timer = 0f;

                isPlayerInRange = true;
            }
            else
            {
                if (timer >= timeBetweenAttacks)
                {
                    DealDamage();
                    timer = 0f;
                }
            }
        }
        else
        {
            isPlayerInRange = false;
        }
    }
    //deal damage function
    public void DealDamage()
    {
        //collides with boxcaster of player
        playermove.TakeDamage(enemyData.damage);
    }

    //take damage function
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

    //draw gizmos for attack radius
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}