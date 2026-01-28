using UnityEngine;

namespace MaskSystem.Runtime
{
    [CreateAssetMenu(fileName = "NouveauMasque", menuName = "Masques")]
    public class MaskData : ScriptableObject
    {
        public string nom;
        public enum TypePouvoir { Aucun, Dash, DoubleSaut, Vitesse, SuperSaut, TraverserMur, VisionGaz, VisionNoir, Soin }
        public TypePouvoir pouvoir;
    }
}