using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mobs {

    public class SmallTank : MonoBehaviour {

        [SerializeField] GameObject wheelsFront;
        [SerializeField] GameObject wheelsRear;
        [SerializeField] float speed;

        private void Update() {
            wheelsFront.transform.Rotate(Vector3.right, speed * Time.deltaTime);
        }

    }

}
