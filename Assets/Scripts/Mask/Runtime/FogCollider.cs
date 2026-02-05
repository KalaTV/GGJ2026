using System.Collections;
using System.Collections.Generic;
using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation; 
using MaskSystem.Runtime;
using Platformer.Mechanics;

namespace Platformer.Mechanics
{
    public class FogCollider : MonoBehaviour
    {
        [Header("Protection")]
        [SerializeField] private MaskAbilityManager abilityManager;

        void OnTriggerEnter2D(Collider2D collider)
        {
            var p = collider.gameObject.GetComponent<PlayerController>();

            if (p != null)
            {

                if (abilityManager != null && abilityManager.activeMask != null && abilityManager.activeMask.pouvoir != MaskData.TypePouvoir.VisionGaz)
                {
                  
                    var ev = Schedule<PlayerEnteredDeathZone>();
                    
                    ev.deathzone = this.gameObject.GetComponent<DeathZone>(); 
                    
                    Debug.Log("Le brouillard a déclenché l'événement de mort !");
                }
                else
                {
                    Debug.Log("Le joueur traverse le brouillard grâce au masque !");
                }
            }
        }
    }
}