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
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                abilityManager.activeMask = inventory.availableMasks[mask];
            }
        }
    }
}