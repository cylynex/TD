using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace UI {

    public class Notifications : MonoBehaviour {

        [SerializeField] TMP_Text noticeDisplay;
        [SerializeField] float textFadeDelay = 3f;

        public void ShowNotice(string notice) {
            print("made it to notice");
            noticeDisplay.text = notice;
            StartCoroutine(FadeText());
            for (int i = 0; i < notice.Length; i++) { }
        }

        IEnumerator FadeText() {
            yield return new WaitForSeconds(textFadeDelay);
            noticeDisplay.text = "";
        }

    }
}
