using UnityEngine;

public class renderCamFollow : MonoBehaviour
{
    public GameObject player;
    public GameObject cam;


    public void Start()
    {
        cam = this.gameObject;
        player = FindFirstObjectByType<character_movement>().gameObject;
    }



    public void Update()
    {
        if (player != null)
        {
            Vector3 newPosition = player.transform.position;

            cam.transform.position = newPosition;
        }

    }
}
