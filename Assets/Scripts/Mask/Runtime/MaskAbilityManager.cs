using System;
using System.Collections;
using System.Collections.Generic;
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

        [SerializeField] private Animator animator;
        [SerializeField] private MaskData baseMask;
        
        [Header("Animator")]
        public AnimatorOverrideController gueparAnimator;
        public AnimatorOverrideController HibouxAnimator;
        public AnimatorOverrideController gazAnimator;
        public AnimatorOverrideController shogunAnimator;
        public AnimatorOverrideController baseAnimator;
        
        [Header("Réglages Dash")]
        public float dashForce = 25f;
        public float dashDuration = 0.2f;
        [SerializeField] ParticleSystem dashParticles;
        private Vector2 startParticlePos;
        
        
        public AnimatorOverrideController AngeAnimator;
        [Header ("Réglages Cooldown")]
        public float cooldownDuration = 5f;
        private bool isCooldown;

        
        
        
        
        void Awake()
        {
            GetComponent<Animator>().runtimeAnimatorController = baseAnimator;
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
            {
                movement.maxSpeed = 15f;
                GetComponent<Animator>().runtimeAnimatorController = gueparAnimator;
            }
            else
            {
                movement.maxSpeed = 6f;
                GetComponent<Animator>().runtimeAnimatorController = baseAnimator;
            }

            
            if (activeMask.pouvoir == MaskData.TypePouvoir.Soin)
            {
                if (health.IsAlive) health.Increment();
                activeMask = baseMask;
            }

            if (activeMask.pouvoir == MaskData.TypePouvoir.SuperSaut)
            {
                movement.jumpTakeOffSpeed = 15f;
                GetComponent<Animator>().runtimeAnimatorController = HibouxAnimator;
            }
            else
            {
                movement.jumpTakeOffSpeed = 9f;
                GetComponent<Animator>().runtimeAnimatorController = baseAnimator;
            }
            if (activeMask.pouvoir == MaskData.TypePouvoir.VisionGaz)
            {
                GetComponent<Animator>().runtimeAnimatorController = gazAnimator;
            }
            else
            {
                GetComponent<Animator>().runtimeAnimatorController = baseAnimator;
            }

            if (activeMask.pouvoir == MaskData.TypePouvoir.Dash)
            {
                GetComponent<Animator>().runtimeAnimatorController = shogunAnimator;
            }
            else
            {
               GetComponent<Animator>().runtimeAnimatorController = baseAnimator;
            }

            if (activeMask.pouvoir == MaskData.TypePouvoir.DoubleSaut)
            {
                GetComponent<Animator>().runtimeAnimatorController = AngeAnimator;    
            }
            else
            {
                GetComponent<Animator>().runtimeAnimatorController = baseAnimator;
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
            movement.controlEnabled = false;
            rb.bodyType = RigidbodyType2D.Dynamic;
            SoundManager.Instance.PlaySound2D("Dash");
            animator.SetBool("Dash", true);
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
            animator.SetBool("Dash", false);
            rb.linearVelocity = Vector2.zero;
            rb.gravityScale = originalGravity;
            movement.controlEnabled = true;
            rb.bodyType = RigidbodyType2D.Kinematic;
        }

        public void SetMask(MaskData mask)
        {
            activeMask = mask;
        }
    }
}