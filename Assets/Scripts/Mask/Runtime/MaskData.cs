using UnityEngine;

namespace MaskSystem.Runtime
{
    [CreateAssetMenu(fileName = "NouveauMasque", menuName = "Masques")]
    public class MaskData : ScriptableObject
    {
        public string nom;
        public Sprite sprite;
        public enum TypePouvoir { Aucun, Dash, DoubleSaut, Vitesse, SuperSaut, VisionGaz, Soin }
        public TypePouvoir pouvoir;
    }
}