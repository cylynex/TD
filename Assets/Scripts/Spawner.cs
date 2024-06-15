using Spawner;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UI;

namespace Mobs {

    public class Spawner : MonoBehaviour {

        [SerializeField] GameObject mob;
        [SerializeField] GameObject[] spawnPoints;
        [SerializeField] GameObject currentSpawnPoint;
        [SerializeField] int numberMobs;
        [SerializeField] int numberMobsSpawned = 0;
        [SerializeField] float timeBetweenMobs;
        [SerializeField] float spawnTimer;

        [SerializeField] Level level;
        [SerializeField] Wave currentWave;
        [SerializeField] int waveCounter;

        [SerializeField] bool randomizeSpawns = true;
        [SerializeField] GameObject[] spawnPointsOrdered;
        [SerializeField] int spawnPointer = 0;
        Notifications notifier;

        private void Start() {
            notifier = FindObjectOfType<Notifications>();
            waveCounter = 0;
            SetLevel();
            SetSpawnPoint();
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
                    spawnPointer++;
                    waveCounter++;
                    SetLevel();         // Sets to the next level
                    SetSpawnPoint();    // Sets spawn point for this wave (randomly) if more than 1 spawn point
                } else {
                    notifier.ShowNotice("All Waves Complete!");
                }
            }
        }

        void SetSpawnPoint() {
            if (randomizeSpawns) {
                int spawnPointToUse = Random.Range(0, spawnPoints.Length - 1);
                currentSpawnPoint = spawnPoints[spawnPointToUse];
            } else {
                // Set the spawn in order of appearance
                currentSpawnPoint = spawnPointsOrdered[spawnPointer];
            }
        }

        void SpawnMob() {
            GameObject thisMob = Instantiate(currentWave.mob, currentSpawnPoint.transform.position, currentSpawnPoint.transform.rotation);
            numberMobsSpawned++;
            spawnTimer = timeBetweenMobs;
        }

    }
}
