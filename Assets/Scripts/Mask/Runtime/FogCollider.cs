using System;
using MaskSystem.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class FogCollider : MonoBehaviour
{
    [SerializeField] private MaskAbilityManager abilityManager;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && abilityManager.activeMask.pouvoir != MaskData.TypePouvoir.DoubleSaut)
        {
            
        }
    }
}
