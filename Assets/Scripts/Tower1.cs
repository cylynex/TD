using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Towers {

    public class Tower1 : MonoBehaviour {

        [SerializeField] Color sphereColor = Color.yellow;
        [SerializeField] float maxRange = 10f;
        [SerializeField] float range = 3f;

        public float detectionRange = 10.0f;        // The range within which the turret can detect enemies
        public LayerMask enemyLayer;                // The layer on which enemies are located
        public Transform turretHead;                // The part of the turret that rotates to aim           
        public GameObject projectilePrefab;         // The projectile to fire at the enemy
        public Transform firePoint;                 // The point from which projectiles are fired

        private Collider[] hitColliders;            // Array to store detected enemies
        public int maxColliders = 10;               // Maximum number of enemies to detect
        [SerializeField] Transform currentTarget;   // The current target enemy
        [SerializeField] float fireRate = 5f;       // The rate of fire of the turret
        [SerializeField] float fireTimer = 0f;      // active timer

        private void OnDrawGizmos() {
            Gizmos.color = sphereColor;
            Gizmos.DrawWireSphere(transform.position, detectionRange);
        }

        private void Start() {
            hitColliders = new Collider[maxColliders];
        }

        private void Update() {
            // Detect enemies within range
            int numColliders = Physics.OverlapSphereNonAlloc(transform.position, detectionRange, hitColliders, enemyLayer);

            // Find the closest target
            float shortestDistance = Mathf.Infinity;
            Collider nearestEnemy = null;

            for (int i = 0; i < numColliders; i++) {
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

            // Aim at the target
            if (currentTarget != null) {
                Vector3 direction = currentTarget.position - turretHead.position;
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                Vector3 rotation = Quaternion.Lerp(turretHead.rotation, lookRotation, Time.deltaTime * 20f).eulerAngles;
                turretHead.rotation = Quaternion.Euler(0f, rotation.y, 0f);

                // Fire at the target
                if (fireTimer <= 0f) {
                    Shoot();
                    fireTimer = fireRate;
                }
            }

            if (fireTimer > 0f) {
                fireTimer -= Time.deltaTime;
            }
        }

        void Shoot() {
            // Instantiate the projectile and set its direction
            GameObject projectileGO = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            Projectile projectile = projectileGO.GetComponent<Projectile>();

            if (projectile != null) {
                projectile.Seek(currentTarget);
            }
        }



    }
}
