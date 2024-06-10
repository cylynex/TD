using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

namespace Mobs {
    public class Navigation : MonoBehaviour {

        [SerializeField] Transform currentDestination;
        NavMeshAgent agent;

        [Header("Movement Stuff")]
        [SerializeField] GameObject destinationList;
        [SerializeField] List<Transform> destinations = new List<Transform>();

        private void Start() {
            destinationList = GameObject.FindGameObjectWithTag("DestinationList");
            GetDestinations();
            agent = GetComponent<NavMeshAgent>();
            currentDestination = destinations[0]; // TODO - Make this handle multiple and calculate for nearest, and move to update
        }

        void GetDestinations() {
            foreach (Transform child in destinationList.transform) {
                destinations.Add(child.transform);
            }
        }

        private void Update() {
            if (currentDestination != null && agent != null) {
                MoveTo(currentDestination.position);
            }
        }

        void MoveTo(Vector3 endDestination) {
            agent.SetDestination(endDestination);
        }

    }
}