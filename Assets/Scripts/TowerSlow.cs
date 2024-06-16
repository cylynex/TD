using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Towers {

    public class TowerSlow : MonoBehaviour {

        Color sphereColor = Color.yellow;
        [Header("Turret Settings")]
        [SerializeField] float maxRange = 10f;          // Max range - TODO - add enlarging range below this
        [SerializeField] float fireRate = 5f;           // The rate of fire of the turret
        [SerializeField] float fireTimer = 0f;          // active timer
        [SerializeField] float idleRotateSpeed = 50f;   // Idle Rotation Speed
        [SerializeField] float detectionRange = 10.0f;  // The range within which the turret can detect enemies

        [Header("Presets")]
        public Transform turretHead;                    // The part of the turret that rotates to aim           
        public GameObject projectilePrefab;             // The projectile to fire at the enemy
        public Transform firePoint;                     // The point from which projectiles are fired
        public LayerMask enemyLayer;                    // The layer on which enemies are located

        private Collider[] hitColliders;                // Array to store detected enemies
        public int maxColliders = 10;                   // Maximum number of enemies to detect
        
        [Header("Target")]
        [SerializeField] Transform currentTarget;       // The current target enemy

        [Header("Upgrade Stuff")]
        [SerializeField] GameObject upgradeButton;      // The upgrade button
        [SerializeField] int currentUpgradeLevel = 1;   // Current Upgrade Level.  Also starts at 1 when new tower is built.
        [SerializeField] int maxUpgradeLevel = 4;       // Max Upgrade Level
        
        private void OnDrawGizmos() {
            Gizmos.color = sphereColor;
            Gizmos.DrawWireSphere(transform.position, detectionRange);
        }

        private void Start() {
            hitColliders = new Collider[maxColliders];
        }

        private void Update() {
            Lock();                 // Select a Target
            Aim();                  // Aim at the target
            AdvanceTimer();         // Move the Timer along if we're waiting for it
            Shoot();                // Shoot if applicable  
            IdleRotation();         // Idle Rotation if no target
        }

        void Lock() {

            // Detect enemies within range
            int numberMobs = Physics.OverlapSphereNonAlloc(transform.position, detectionRange, hitColliders, enemyLayer);

            // Find the closest target
            float shortestDistance = Mathf.Infinity;
            Collider nearestEnemy = null;

            for (int i = 0; i < numberMobs; i++) {
                Collider enemyCollider = hitColliders[i];
                float distanceToEnemy = Vector3.Distance(transform.position, enemyCollider.transform.position);

                if (distanceToEnemy < shortestDistance) {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemyCollider;
                }
            }

            // Lock onto the closest target
            if (nearestEnemy != null) {
                currentTarget = nearestEnemy.transform;
            }
            else {
                currentTarget = null;
            }
        }

        void Aim() {
            if (currentTarget != null) {
                Vector3 direction = currentTarget.position - turretHead.position;
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                Vector3 rotation = Quaternion.Lerp(turretHead.rotation, lookRotation, Time.deltaTime * 20f).eulerAngles;
                turretHead.rotation = Quaternion.Euler(0f, rotation.y, 0f);
            }
        }

        void AdvanceTimer() {
            if (fireTimer > 0f) {
                fireTimer -= Time.deltaTime;
            }
        }

        void Shoot() {
            if (currentTarget != null && fireTimer <= 0) {

                GameObject projectileGO = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
                Projectile projectile = projectileGO.GetComponent<Projectile>();

                if (projectile != null) {
                    projectile.Seek(currentTarget);
                }

                // Reset the timer
                fireTimer = fireRate;
            }
        }

        void IdleRotation() {
            if (currentTarget == null) {
                turretHead.Rotate(Vector3.up, idleRotateSpeed * Time.deltaTime);
            }
        }

        private void OnMouseDown() {
            print("open the upgrade menu here");
            upgradeButton.SetActive(true);
        }


    }
}
