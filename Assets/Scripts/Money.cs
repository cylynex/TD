using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Core {

    public class Money : MonoBehaviour {

        [SerializeField] int money = 0;
        public int GetMoney {  get { return money; } }

        [Header("Money Stuff")]
        [SerializeField] TMP_Text moneyDisplay;
        
        public void EarnMoney(int amount) {
            money += amount;
            UpdateMoneyDisplay();
        }

        public void SpendMoney(int amount) {
            if ((money - amount) >= 0) { 
                money -= amount; 
                UpdateMoneyDisplay();
             } else {
                print("cant spend, not enough money, should have been handled earlier tho");
            }
        }

        void UpdateMoneyDisplay() {
            moneyDisplay.text = money.ToString();
            print("updated");
        }

    }
}
