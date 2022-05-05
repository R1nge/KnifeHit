using UnityEngine;

namespace Skins
{
    public class SkinManager : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Skin skin;

        private void Start() => spriteRenderer.sprite = skin.sprite;
    }
}