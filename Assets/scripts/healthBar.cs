using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class healthBar : MonoBehaviour
{
    character_movement character;
    public Image healbar;

    private void Start()
    {
      
    }

    private void Update()
    {
        healbar.fillAmount = Mathf.Clamp(character.currentHealth / character.maxHealth, 0, 1);
    }
}
