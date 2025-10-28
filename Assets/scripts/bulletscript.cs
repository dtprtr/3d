using NUnit.Framework;
using UnityEngine;

public class bulletscript : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    public float damage;
    public LayerMask enemyLayer;
    public LayerMask playerLayer;
    public float lifeTime;
    



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.linearVelocity = transform.forward * speed;

    }

    void Update()
    {
       
        Destroy(gameObject, lifeTime);
    }


    public void OnTriggerEnter(Collider hit)
    {
        
      enemyMoveAttack enemy = hit.GetComponent<enemyMoveAttack>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
        Debug.Log("hit " + hit.name);
    }
}