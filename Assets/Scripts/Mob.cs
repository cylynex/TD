using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Mobs {

    public class Mob : MonoBehaviour {

        [SerializeField] int moneyValue = 1;
        NavMeshAgent nav;
        [SerializeField] float slowTimer = 0;
        [SerializeField] bool slowed = true;

        private void Start() {
            nav = GetComponent<NavMeshAgent>(); 
        }

        private void Update() {
            if (slowed) {
                if (slowTimer > 0) {
                    slowTimer -= Time.deltaTime;
                }

                if (slowTimer <= 0) {
                    slowed = false;
                    slowTimer = 0;
                }
            }
        }

        public void Die() {
            print("mob has died send money");
            Money moneyManager = FindObjectOfType<Money>();
            moneyManager.EarnMoney(moneyValue);
        }

        public void Slowed(float amountSlow, float amountTime) {
            slowTimer = amountTime;
            slowed = true;
            nav.speed = nav.speed - amountSlow;
        }

        public void UnSlowed() {

        }

    }

}
