using System;
using UnityEngine;
using UnityEngine.UI;

namespace MaskSystem.Runtime
{
    public class MaskInWorld : MonoBehaviour
    {
        [SerializeField] private MaskData mask;
        [SerializeField] private MaskAbilityManager abilityManager;
        
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                abilityManager.activeMask = mask;
                            Destroy(gameObject);
            }
        }
    }
}