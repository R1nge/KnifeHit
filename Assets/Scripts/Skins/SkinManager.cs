using System.Collections.Generic;
using Core;
using UnityEngine;

namespace Skins
{
    public class SkinManager : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private List<Skin> skins;
        private Skin _skin;
        private Wallet _wallet;
        private int _skinIndex;

        private void Awake()
        {
            _wallet = FindObjectOfType<Wallet>();
            _skinIndex = PlayerPrefs.GetInt("Index", 0);
            _skin = skins[_skinIndex];
        }

        private void Start() => ChangeSkin(_skinIndex);

        public void ChangeSkin(int index)
        {
            if (!skins[index].isUnlocked)
            {
                if (!_wallet.Spend(skins[index].price)) return;
                _skinIndex = index;
                _skin = skins[_skinIndex];
                _skin.isUnlocked = true;
                spriteRenderer.sprite = _skin.sprite;
            }
            else
            {
                _skinIndex = index;
                _skin = skins[_skinIndex];
                spriteRenderer.sprite = _skin.sprite;
            }

            PlayerPrefs.SetInt("Index", _skinIndex);
            PlayerPrefs.Save();
        }
    }
}