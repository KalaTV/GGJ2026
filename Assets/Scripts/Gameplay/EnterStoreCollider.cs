using UnityEngine;
using UnityEngine.InputSystem; 

namespace Platformer.Gameplay
{
    public class EnterStoreCollider : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player" && Input.GetKey("Interact"))
            {
                collision.gameObject.SendMessage("OnEnterStore");
            }
        }
    }
}