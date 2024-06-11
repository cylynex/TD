using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spawner {

    [CreateAssetMenu(fileName = "Level", menuName = "Level", order = 10)]
    public class Level : ScriptableObject {
        public string levelName;
        public Wave[] waves;
        public int timeBetweenWaves;
    }
}
