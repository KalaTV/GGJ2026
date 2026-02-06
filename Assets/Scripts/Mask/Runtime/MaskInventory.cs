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
        public void EquipMaskByName(string nameToFind)
        {
            // On parcourt toute la liste des masques disponibles
            for (int i = 0; i < availableMasks.Count; i++)
            {
                // On compare le nom du ScriptableObject avec le nom que tu as écrit
                // "availableMasks[i].name" c'est le nom du fichier dans ton dossier Project
                if (availableMasks[i].name == nameToFind)
                {
                    EquipMask(i); // On réutilise ta fonction existante qui marche bien
                    return; // On arrête de chercher, on a trouvé
                }
            }

            Debug.LogError("Erreur : Aucun masque nommé '" + nameToFind + "' n'a été trouvé dans l'inventaire !");
        }
        public void EquipMask(int index)
        {
            if(index < 0 || index >= availableMasks.Count)
                return;
            
            abilityManager.activeMask = availableMasks[index];
        }
    }
}