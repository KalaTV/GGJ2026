using UnityEngine;
using TMPro;
using MaskSystem.Runtime;

public class MaskCounterUI : MonoBehaviour
{
    [Header("Références")]
    [SerializeField] private MaskInventory inventory;
    [SerializeField] private TextMeshProUGUI counterText;

    [Header("Configuration")]
    public string maskToIgnore = "nomask"; // Le nom exact de ton ScriptableObject vide
    public int totalMasksInGame = 5;       // Le nombre total (sans compter le vide)

    void Update()
    {
        if (inventory != null && counterText != null)
        {
            int count = 0;

            
            foreach (var m in inventory.availableMasks)
            {
                
                if (m != null && m.name.ToLower() != maskToIgnore.ToLower())
                {
                    count++;
                }
            }

            
            counterText.text = count + " / " + totalMasksInGame;
        }
    }
}