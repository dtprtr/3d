using UnityEngine;

public class bulletscript : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    public int damage;
    public LayerMask enemyLayer;
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


    private void OnTriggerEnter()
    {
        if ( gameObject.layer == enemyLayer)
        {
            // Deal damage to enemy

        }
            
            
            
    }
}
