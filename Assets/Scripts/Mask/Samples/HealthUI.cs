using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    public Platformer.Mechanics.Health playerHealth; 
    public List<Image> hearts; 
    
    public Sprite fullHeart;   
    public Sprite emptyHeart;  

    void Update()
    {
        UpdateHearts();
    }

    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Count; i++)
        {
            if (i < playerHealth.currentHP)
            {
                hearts[i].sprite = fullHeart;
                hearts[i].enabled = true; 
            }
            else
            {
                hearts[i].sprite = emptyHeart;
                
            }
            
            if (i >= playerHealth.maxHP)
            {
                hearts[i].gameObject.SetActive(false);
            }
            else
            {
                hearts[i].gameObject.SetActive(true);
            }
        }
    }
}
