using System.Collections;
using System.Collections.Generic; 
using UnityEngine;

public class character_movement : MonoBehaviour
{
    private CharacterController controller;
    public float speed = 5f;

   

    public LayerMask damageMask;
    public Vector3 boxSize;
    public float castDistance;

    [HideInInspector] public float gravity = -9.81f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //horizontal movement
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * speed);

        //gravity
        gravity += -9.81f * Time.deltaTime;
        controller.Move(new Vector3(0, gravity, 0) * Time.deltaTime);
        //jumping




    }
    public bool isHit()
    {
        return Physics.BoxCast(transform.position, boxSize, Vector3.down, Quaternion.identity, castDistance, damageMask);
    }
    private void OnDrawGizmos()
    {
       Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + Vector3.down * castDistance, boxSize * 2);
    }
}

