using System;
using System.Diagnostics.SymbolStore;
using UnityEngine;
using UnityEngine.UI;

namespace MaskSystem.Runtime
{
    public class MaskInWorld : MonoBehaviour
    {
        [SerializeField] private MaskData mask;
        [SerializeField] private MaskAbilityManager abilityManager;
        [SerializeField] private MaskInventory inventory;
        [SerializeField] private SpriteRenderer spriteRenderer;

        private void Start()
        {
            spriteRenderer.sprite = mask.sprite;
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                abilityManager.activeMask = mask;
                inventory.availableMasks.Add(mask);
                            Destroy(gameObject);
            }
        }
    }
}