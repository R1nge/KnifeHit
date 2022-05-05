using Core;
using UnityEngine;

namespace Skins
{
    public class SkinManager : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Skin skin;
        private Wallet _wallet;

        private void Awake() => _wallet = FindObjectOfType<Wallet>();

        private void Start() => spriteRenderer.sprite = skin.sprite;

        public void ChangeSkin(Skin _skin)
        {
            if (!_skin.isUnlocked)
            {
                if (!_wallet.Spend(_skin.price)) return;
                skin = _skin;
                skin.isUnlocked = true;
                spriteRenderer.sprite = skin.sprite;
            }
            else
            {
                skin = _skin;
                spriteRenderer.sprite = _skin.sprite;
            }
        }
    }
}