using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mobs {

    public class HitPoints : MonoBehaviour {

        [SerializeField] int hitPoints;

        public void TakeDamage(int damage) {
            hitPoints -= damage;
            if (hitPoints <= 0) {
                print("mob dying");
                Destroy(gameObject);
            }
        }

    }
}
