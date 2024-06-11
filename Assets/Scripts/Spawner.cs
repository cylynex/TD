using Spawner;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Mobs {

    public class Spawner : MonoBehaviour {

        [SerializeField] GameObject mob;
        [SerializeField] GameObject spawnPoint;
        [SerializeField] int numberMobs;
        [SerializeField] int numberMobsSpawned = 0;
        [SerializeField] float timeBetweenMobs;
        [SerializeField] float spawnTimer;

        [SerializeField] Level level;
        [SerializeField] Wave currentWave;
        [SerializeField] int waveCounter;

        private void Start() {

            // Debug
            // print("Level found is: " + level.name);
            // print("Number of waves is: " + level.waves.Length);
            // print("First Wave Information: " + level.waves[0].mob.name);
            // print("mobs in first wave: " + level.waves[0].numberOfMobs);

            waveCounter = 0;
            SetLevel();
            spawnTimer = 0;
        }

        void SetLevel() {
            currentWave = level.waves[waveCounter];
            numberMobs = level.waves[waveCounter].numberOfMobs;
            numberMobsSpawned = 0;
            spawnTimer = level.timeBetweenWaves;
        }


        private void Update() {

            if (spawnTimer > 0) {
                spawnTimer -= Time.deltaTime;
            }

            if (spawnTimer <= 0 && numberMobsSpawned < numberMobs) {
                SpawnMob();
            } else if (spawnTimer <= 0 && numberMobsSpawned >= numberMobs) {
                // ran outta mobs, go to next wave or end if that was last wave
                if (waveCounter < level.waves[0].numberOfMobs) {
                    print("moving to next wave");
                    waveCounter++;
                    SetLevel();     // Sets to the next level
                } else {
                    print("OUT OF WAVES - TODO Add finish to this loop.");
                }
            }

            // Basic Spawner - deprecated
            /*
            if (numberMobsSpawned < numberMobs) {
                spawnTimer -= Time.deltaTime;
                if (spawnTimer <= 0) {
                    SpawnMob();
                }
            }
            */
        }

        void SpawnMob() {
            GameObject thisMob = Instantiate(currentWave.mob, spawnPoint.transform.position, Quaternion.identity);
            numberMobsSpawned++;
            spawnTimer = timeBetweenMobs;
        }

        void SpawnMobOld() {
            GameObject thisMob = Instantiate(mob, spawnPoint.transform.position, Quaternion.identity);
            numberMobsSpawned++;
            spawnTimer = timeBetweenMobs;
        }

    }
}
