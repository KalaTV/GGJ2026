using System;
using Unity.VisualScripting;
using UnityEngine;

namespace MaskSystem.Runtime
{
    public class ColliderChangeMask : MonoBehaviour
    {
        [SerializeField] private MaskInventory inventory;
        [SerializeField] private MaskAbilityManager abilityManager;
        [SerializeField] private int mask;
        [Header("Réglages")]
        [SerializeField] private string maskName;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                inventory.EquipMaskByName(maskName);
            }
        }
    }
}