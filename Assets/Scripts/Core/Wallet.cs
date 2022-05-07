using System;
using UnityEngine;

namespace Core
{
    public class Wallet : MonoBehaviour
    {
        [SerializeField] private int money;
        private const string MONEY = "Money";

        public event Action<int> OnMoneyAmountChanged;

        private void Start() => Load();

        public bool Spend(int amount)
        {
            if (amount <= 0) return false;
            if (money - amount < 0) return false;
            money -= amount;
            OnMoneyAmountChanged?.Invoke(money);
            Save();
            return true;
        }

        public void Earn(int amount)
        {
            if (amount < 0) return;
            money += amount;
            OnMoneyAmountChanged?.Invoke(money);
            Save();
        }

        private void Save()
        {
            PlayerPrefs.SetInt(MONEY, money);
            PlayerPrefs.Save();
        }

        private void Load()
        {
            money = PlayerPrefs.GetInt(MONEY, 0);
            OnMoneyAmountChanged?.Invoke(money);
        }
    }
}