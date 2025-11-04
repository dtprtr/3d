using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
public class character_movement : MonoBehaviour
{
    private CharacterController controller;
    public float speed = 5f;

    private healthBar healthBar;

    public float currentHealth;
    public float maxHealth;

    public int killCount;
    


    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
    private void Start()
    {
        
        

        
    }

    // Update is called once per frame
    void Update()
    {

        // horizontal movement (normalized to avoid faster diagonal movement)
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (move.sqrMagnitude > 1f) // more efficient than magnitude
        {
            move = move.normalized;
        }
        controller.Move(move * speed * Time.deltaTime);
        

       
       

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
        Debug.Log("Player has died.");
   }
    
}
