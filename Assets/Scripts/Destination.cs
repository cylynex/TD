using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace Mobs {

    public class Destination : MonoBehaviour {

        [SerializeField] Lives lives;

        private void Start() {
            lives = FindObjectOfType<Lives>();
        }

        private void OnTriggerEnter(Collider other) {
            if (other.tag == "Mob") {
                lives.LoseALife();
                Destroy(other.gameObject);
            }
        }

    }
}