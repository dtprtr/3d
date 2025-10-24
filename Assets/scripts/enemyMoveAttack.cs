using UnityEngine;

public class enemyMoveAttack : MonoBehaviour
{
    [SerializeField]
    enemyscriptable enemyData;
    private Transform toPlayer;
    public GameObject player;

    public LayerMask damageToPlayerMask;

    public Vector3 boxSize;
    public float castDistance;

    public CharacterController controller;
    void Start()
    {
        GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
        controller.Move(transform.forward * enemyData.speed * Time.deltaTime);

        if (HitPlayer())
        {

           
        }

    }


    public bool HitPlayer()
    {
        transform.LookAt(player.transform);
        return Physics.BoxCast(transform.position, boxSize, Vector3.down, Quaternion.identity, castDistance);
    }
    private void OnDrawGizmos()
    {
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + Vector3.down * castDistance, boxSize * 2);
    }
}
