using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "SpawnChance", menuName = "ScriptableObjects/SpawnChance", order = 1)]
    public class SpawnChance : ScriptableObject
    {
        public int chance;
    }
}