using System;
using UnityEngine;
using UnityEngine.InputSystem; 

namespace Platformer.Gameplay
{
    public class EnterStoreCollider : MonoBehaviour
    { 
        public void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.CompareTag("Player") )
            {
                Debug.Log("OnEnterStore");
            }
        }
    }
}