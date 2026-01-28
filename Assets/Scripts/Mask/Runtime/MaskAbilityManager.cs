using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem; 
using Platformer.Mechanics;
using Unity.VisualScripting;

namespace MaskSystem.Runtime
{
    public class MaskAbilityManager : MonoBehaviour
    {
        public MaskData activeMask;
        
        private Rigidbody2D rb;
        private Health health;
        private PlayerController movement;
        private PlayerInput playerInput; 
        private SpriteRenderer sr;       

        [Header("Réglages Dash")]
        public float dashForce = 25f;
        public float dashDuration = 0.2f;
        [SerializeField] ParticleSystem dashParticles;
        private Vector2 startParticlePos;
        
        [Header ("Réglages Cooldown")]
        public float cooldownDuration = 5f;
        private bool isCooldown;

        
        
        void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            health = GetComponent<Health>();
            movement = GetComponent<PlayerController>();
            playerInput = GetComponent<PlayerInput>();
            sr = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            startParticlePos = dashParticles.transform.localPosition;
        }

        private void Update()
        {
            if (activeMask.pouvoir == MaskData.TypePouvoir.Vitesse)
                movement.maxSpeed = 15f;
            else
            {
                movement.maxSpeed = 6f;
            }
        }

        void OnSpecialAbility(InputValue value)
        {
            if (value.isPressed && activeMask != null)
            {
                TriggerSpecialAbility();
            }
        }

        void TriggerSpecialAbility()
        {
            
            switch (activeMask.pouvoir) 
            {
                case MaskData.TypePouvoir.Dash:
                    if (isCooldown == false)
                    {
                        StartCoroutine(DashRoutine());
                        StartCoroutine(StartCooldown());
                    }
                    break;
                case MaskData.TypePouvoir.Soin:
                    if (health.IsAlive) health.Increment();
                    break;
            }
        }

        IEnumerator StartCooldown()
        {
            while (cooldownDuration > 0)
            {
                isCooldown = true;
                cooldownDuration -= Time.deltaTime;
                yield return null;
            }
            isCooldown = false;
        }
        
        IEnumerator DashRoutine() 
        {
            dashParticles.Play();
            float originalGravity = rb.gravityScale;
            rb.gravityScale = 0.1f; 
            
            Vector2 input = playerInput.actions["Move"].ReadValue<Vector2>();
            float directionX = (Mathf.Abs(input.x) > 0.1f) ? Mathf.Sign(input.x) : (sr.flipX ? -1 : 1);
            if (sr.flipX)
            {
                 dashParticles.transform.localScale = new Vector3(-2f, -2f, -2f);
            }
            else
            {
                dashParticles.transform.localScale = new Vector3(2f, 2f, 2f);
            }
            float timer = 0;
            while (timer < dashDuration)
            {
                rb.linearVelocity = new Vector2(directionX * dashForce, 0); 

                timer += Time.deltaTime;
                yield return null;
            }
            
            rb.linearVelocity = Vector2.zero;
            rb.gravityScale = originalGravity;
        }

        public void SetMask(MaskData mask)
        {
            activeMask = mask;
        }
    }
}