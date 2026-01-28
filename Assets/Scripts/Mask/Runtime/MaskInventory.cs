using System;
using UnityEngine;
using System.Collections.Generic;


namespace MaskSystem.Runtime
{
    public class MaskInventory : MonoBehaviour
    {
        public List<MaskData> availableMasks = new List<MaskData>();
        public int currentMask = 0;
        private MaskAbilityManager abilityManager;

        private void Start()
        {
            abilityManager = GetComponent<MaskAbilityManager>();
        }

        public void EquipMask(int index)
        {
            currentMask = index;
            abilityManager.activeMask = availableMasks[index];
        }
    }
}