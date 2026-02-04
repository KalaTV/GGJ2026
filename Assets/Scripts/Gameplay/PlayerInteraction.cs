using UnityEngine;
using UnityEngine.InputSystem; 
using Platformer.Mechanics;
using System.Collections;

namespace Platformer.Gameplay
{
    
    
    public class PlayerInteraction : MonoBehaviour
    {
        private bool isNearDoor = false; 
         private EnterStoreCollider currentDoor = null; 
         private PlayerController movement;
        void Awake()
        {
            movement = GetComponent<PlayerController>();
        }

        void OnInteract(InputValue value)
        {
            
            if (value.isPressed && isNearDoor && currentDoor != null)
            {
                
                StartCoroutine(EnterRoomSequence());
            }
        }

        private IEnumerator EnterRoomSequence()
        {
            movement.controlEnabled = false;
            
            yield return new WaitForSeconds(0.5f);
            
            Debug.Log("Le joueur est entré dans la pièce !");
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Door"))
            {
                isNearDoor = true;
                currentDoor = other.GetComponent<EnterStoreCollider>();
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Door"))
            {
                isNearDoor = false;
                currentDoor = null;
            }
        }
    }
}