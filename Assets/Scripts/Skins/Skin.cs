using UnityEngine;

namespace Skins
{
    [CreateAssetMenu(fileName = "Skin", menuName = "ScriptableObjects/Skin", order = 1)]
    public class Skin : ScriptableObject
    {
        public Sprite sprite;

        public void ChangeSkin(Sprite sprite)
        {
            this.sprite = sprite;
        }
    }
}