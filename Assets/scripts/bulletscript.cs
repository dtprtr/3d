using UnityEngine;

public class bulletscript : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    public int damage;
    public LayerMask enemyLayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.linearVelocity = transform.forward * speed;
    }




    private void OnTriggerEnter()
    {
        if ( gameObject.layer == enemyLayer)
        {
            // Deal damage to enemy

        }
            
            
            
    }
}
