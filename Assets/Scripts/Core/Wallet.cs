using System;
using System.ComponentModel.Design;
using UnityEngine;

namespace Core
{
    public class Wallet : MonoBehaviour
    {
        [SerializeField] private int money;
        private const string MONEY = "Money";

        private void Start() => Load();

        public bool Spend(int amount)
        {
            if (money - amount < 0) return false;
            money -= amount;
            Save();
            return true;
        }

        public void Earn(int amount)
        {
            if (amount < 0)
                throw CheckoutException.Canceled;

            money += amount;
            Save();
        }

        private void Save()
        {
            PlayerPrefs.SetInt(MONEY, money);
            PlayerPrefs.Save();
        }

        private void Load() => money = PlayerPrefs.GetInt(MONEY, 0);
    }
}