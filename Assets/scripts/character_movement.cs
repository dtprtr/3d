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
        // Plan (pseudocode):
        // 1. Read horizontal and vertical input axes into a Vector3 (x,z).
        // 2. Preserve analog magnitude when < 1 (joystick) but prevent diagonal speed boost:
        //    - If magnitude > 1, normalize to length 1 (clamp max speed).
        // 3. Multiply by speed and Time.deltaTime and move the character controller.
        // 4. Apply gravity separately (existing code).

        // horizontal movement (normalized to avoid faster diagonal movement)
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (move.sqrMagnitude > 1f) // more efficient than magnitude
        {
            move = move.normalized;
        }
        controller.Move(move * speed * Time.deltaTime);

        // gravity
        gravity += -9.81f * Time.deltaTime;
        controller.Move(new Vector3(0, gravity, 0) * Time.deltaTime);
       




    }
    public bool isHit()
    {
        return Physics.BoxCast(transform.position, boxSize, Vector3.down, Quaternion.identity, castDistance, damageMask);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position + Vector3.down * castDistance, boxSize * 2);
    }
}

