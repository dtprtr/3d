using UnityEngine;

public class playerShoot : MonoBehaviour
{
    public bool canShoot;
    private float timeBetweenShots;
    public float timer;
    public GameObject bulletPrefab;
    public Transform bulletTransform;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!canShoot)
        {
            timer += Time.deltaTime;
            if( timer > timeBetweenShots)
            {
                canShoot = true;
                timer = 0f;
            }
        }
        if (Input.GetMouseButton(0) && canShoot)
        {
            canShoot = false;
            Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, bulletTransform.position, Quaternion.identity);

    }
}
