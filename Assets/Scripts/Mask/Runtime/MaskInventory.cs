using System;
using UnityEngine;
using System.Collections.Generic;


namespace MaskSystem.Runtime
{
    public class MaskInventory : MonoBehaviour
    {
        public List<MaskData> availableMasks = new List<MaskData>();
        private MaskAbilityManager abilityManager;

        private void Start()
        {
            abilityManager = GetComponent<MaskAbilityManager>();
        }

        public void EquipMask(int index)
        {
            if(index < 0 || index >= availableMasks.Count)
                return;
            
            abilityManager.activeMask = availableMasks[index];
        }
    }
}