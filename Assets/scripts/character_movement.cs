using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
public class character_movement : MonoBehaviour
{
    private CharacterController controller;
    public float speed = 5f;

    public GameObject gameOverPan;
    public TextMeshProUGUI gameOverNum;
    public int gameOverScore;
   
    public float currentHealth;
    public float maxHealth;
    

    private float invinciblity;
    public float invincibiltyTime;

    public TextMeshProUGUI killCountText;
    [HideInInspector] public int currScore;


    private void OnDestroy()
    {
        gameOverPan.SetActive(true);
        gameOverNum.text = gameOverScore.ToString("0");
        Time.timeScale = 0f;
    }
    private void Awake()
    {
        
        controller = GetComponent<CharacterController>();
    }

    private void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        gameOverScore = currScore;
        // horizontal movement (normalized to avoid faster diagonal movement)
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (move.sqrMagnitude > 1f) // more efficient than magnitude
        {
            move = move.normalized;
        }
        controller.Move(move * speed * Time.deltaTime);


        invinciblity -= Time.deltaTime;

        killCountText.text = currScore.ToString("0");

    }

    public void TakeDamage(float damage)
    {
        
        if (invinciblity > 0)
            return;

        invinciblity = invincibiltyTime;

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


   