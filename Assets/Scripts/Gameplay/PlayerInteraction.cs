using UnityEngine;
using UnityEngine.InputSystem; 
using Platformer.Mechanics;
using System.Collections;

namespace Platformer.Gameplay
{
    
    
    public class PlayerInteraction : MonoBehaviour
    {
        private bool isNearDoor = false; 
         private PlayerController movement;
        void Awake()
        {
            movement = GetComponent<PlayerController>();
        }
        void OnInteract(InputValue value)
        {
            
            if (value.isPressed && isNearDoor)
            {
                
                StartCoroutine(EnterRoomSequence());
            }
        }

        private IEnumerator EnterRoomSequence()
        {
            movement.controlEnabled = false;
            
            yield return new WaitForSeconds(0.5f);
            
            Debug.Log("entré madame");
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Door"))
            {
                isNearDoor = true;
                Debug.Log("jsuis dans la porte");
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Door"))
            {
                isNearDoor = false;
            }
        }
    }
}