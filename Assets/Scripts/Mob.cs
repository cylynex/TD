using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mobs {

    public class Mob : MonoBehaviour {

        [SerializeField] int moneyValue = 1;

        public void Die() {
            print("mob has died send money");
            Money moneyManager = FindObjectOfType<Money>();
            moneyManager.EarnMoney(moneyValue);
        }

    }

}
