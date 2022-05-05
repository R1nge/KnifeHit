using UnityEngine;

namespace Skins
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
    public class Skin : ScriptableObject
    {
        public Sprite sprite;
    }
}