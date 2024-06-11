using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Costs : MonoBehaviour {

    [Header("Costs")]
    [SerializeField] int baseCost;
    public int GetCost { get { return baseCost; } } // TODO - This will need to be a method to determine level and return the current upgrade cost eventualy.

}
