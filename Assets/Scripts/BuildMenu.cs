using Core;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Towers {

    public class BuildMenu : MonoBehaviour {

        [SerializeField] GameObject menu;
        [SerializeField] GameObject selectedTowerBase;
        Money money;

        public void ShowMenu(GameObject baseToUse) {
            menu.SetActive(true);
            selectedTowerBase = baseToUse;
            money = FindObjectOfType<Money>();
        }

        public void BuildTower(GameObject towerToBuild) {

            if (selectedTowerBase.GetComponent<TowerBase>().ShowOccupied == false) {

                print("cost: " + towerToBuild.GetComponent<Costs>().GetCost);
                int currentCost = towerToBuild.GetComponent<Costs>().GetCost;
                if (currentCost <= money.GetMoney) {
                    CompleteBuilding(towerToBuild, currentCost);
                } else {
                    // TODO - Notify UI of insufficient funds
                    print("not enough dough");
                }
                
            }
        }

        void CompleteBuilding(GameObject towerToBuild, int cost) {
            Vector3 buildPosition = new Vector3(0, 0.5f, 0);
            GameObject newTower = Instantiate(towerToBuild, buildPosition, Quaternion.identity, selectedTowerBase.transform);
            newTower.transform.localPosition = buildPosition;
            selectedTowerBase.GetComponent<TowerBase>().SetOccupied();
            menu.SetActive(false);
            money.SpendMoney(cost);
        }

    }
}