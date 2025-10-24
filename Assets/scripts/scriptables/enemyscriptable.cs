using UnityEngine;


[CreateAssetMenu(fileName = "enemyscriptable", menuName = "Scriptable Objects/enemyscriptable")]
public class enemyscriptable : ScriptableObject
{
    public float health;
    public float speed;
    public float damage;
    public GameObject enemyPrefab;
   
    
}
