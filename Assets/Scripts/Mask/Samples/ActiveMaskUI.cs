using System;
using MaskSystem.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class ActiveMaskUI : MonoBehaviour
{
   public Image mask;
   private Sprite maskSprite;

   [SerializeField]
   MaskAbilityManager maskAbilityManager;


   private void Update()
   {
      UpdateMaskUI();
   }

   private void UpdateMaskUI()
   {
      maskSprite = maskAbilityManager.activeMask.sprite;
      mask.sprite = maskSprite;
   }
}
