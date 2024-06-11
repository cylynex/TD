using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Towers {

    public class BuildMenu : MonoBehaviour {

        [SerializeField] GameObject menu;
        [SerializeField] GameObject selectedTowerBase;

        public void ShowMenu(GameObject baseToUse) {
            menu.SetActive(true);
            selectedTowerBase = baseToUse;
        }

        public void BuildTower(GameObject towerToBuild) {
            if (selectedTowerBase.GetComponent<TowerBase>().ShowOccupied == false) {
                Vector3 buildPosition = new Vector3(0, 0.5f, 0);
                GameObject newTower = Instantiate(towerToBuild, buildPosition, Quaternion.identity, selectedTowerBase.transform);
                newTower.transform.localPosition = buildPosition;
                selectedTowerBase.GetComponent<TowerBase>().SetOccupied();
                menu.SetActive(false);
            }
        }

    }
}