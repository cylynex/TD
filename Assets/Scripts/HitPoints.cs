using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mobs {

    public class HitPoints : MonoBehaviour {

        [SerializeField] int hitPoints;
        [SerializeField] int maxHitPoints;

        private float currentHealth;
        [SerializeField] HealthBar hpBar;

        private void Start() {
            currentHealth = maxHitPoints;
            hpBar.SetMaxHealth(maxHitPoints);
        }

        public void TakeDamage(int damage) {
            hitPoints -= damage;
            if (hitPoints <= 0) {
                Destroy(hpBar.gameObject);
                Destroy(gameObject);
            } else {
                // Update the health bar
                hpBar.SetHealth(hitPoints);
            }
        }



    }
}
