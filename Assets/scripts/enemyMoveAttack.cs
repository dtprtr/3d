using JetBrains.Annotations;
using System;
using Unity.VisualScripting;
using UnityEngine;

public class enemyMoveAttack : MonoBehaviour
{
    [SerializeField]
    enemyscriptable enemyData;
    [SerializeField]
    public float currentHealth;
    public GameObject player;

    public float timeBetweenAttacks;
    private float timer;

    public float range;
    public LayerMask playerLayer;



    private character_movement playermove;
    public CharacterController controller;
    void Start()
    {
        currentHealth = enemyData.maxhealth;
        GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        playerhit();

        if (player != null)
        {
            transform.LookAt(player.transform);
            controller.Move(transform.forward * enemyData.speed * Time.deltaTime);
        }


        if (timer <= 0 && playermove)
        {
            playermove?.TakeDamage(enemyData.damage);
            timer = timeBetweenAttacks;
        }
        else
        {
            timer -= Time.deltaTime;
        }
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

    public void playerhit()
    {
       RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward, out hit, range, playerLayer);
       if (hit.collider != null)
        {
            Debug.Log("Player hit");
            playermove = hit.collider.GetComponent<character_movement>();
        }

    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * range);
    }



}   