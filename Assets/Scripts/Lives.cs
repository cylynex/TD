using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace UI { 
    public class Lives : MonoBehaviour {

        [SerializeField] int lives;
        [SerializeField] TMP_Text livesDisplay;

        private void Start() {
            UpdateDisplay();
        }

        public void LoseALife() {
            lives--;
            UpdateDisplay();
            if (lives <= 0) { 
                print("GAME OVER YOU LOSE SIR");
                Time.timeScale = 0;
            }
        }

        void UpdateDisplay() {
            livesDisplay.text = lives.ToString();
        }

    }
}
