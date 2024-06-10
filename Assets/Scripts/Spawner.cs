using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mobs {

    public class Spawner : MonoBehaviour {

        [SerializeField] GameObject mob;
        [SerializeField] GameObject spawnPoint;
        [SerializeField] int numberMobs;
        [SerializeField] int numberMobsSpawned = 0;
        [SerializeField] float timeBetweenMobs;
        [SerializeField] float spawnTimer;

        private void Update() {
            if (numberMobsSpawned < numberMobs) {
                spawnTimer -= Time.deltaTime;
                if (spawnTimer <= 0) {
                    SpawnMob();
                }
            }
        }

        void SpawnMob() {
            print("spawn");
            GameObject thisMob = Instantiate(mob, spawnPoint.transform.position, Quaternion.identity);
            numberMobsSpawned++;
            spawnTimer = timeBetweenMobs;
        }

    }
}
