using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spawner {

    [CreateAssetMenu(fileName="Wave", menuName ="Wave", order = 20)]
    public class Wave : ScriptableObject {

        public string waveName;
        public GameObject mob;
        public int numberOfMobs;


    }

}
