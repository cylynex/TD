using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Towers {
    
    public class TowerBase : MonoBehaviour {

        [SerializeField] GameObject buildMenu;
        [SerializeField] bool isOccupied = false;
        public bool ShowOccupied { get { return isOccupied; } }

        private void Awake() {
            buildMenu = FindObjectOfType<BuildMenu>().gameObject;
        }

        private void OnMouseDown() {
            if (!isOccupied) {
                buildMenu.GetComponent<BuildMenu>().ShowMenu(gameObject);
            }
        }

        public void SetOccupied() {
            isOccupied = true;
        }

    }
}