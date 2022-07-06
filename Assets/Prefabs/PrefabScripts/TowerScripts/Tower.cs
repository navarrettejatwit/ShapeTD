using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Enums for Towers, so that they could be slotted into towerspawner.
[System.Serializable]
public class Tower : MonoBehaviour, Product
{


    public TowerType towerType;

}

public enum TowerType
{
    Tower_Standard,
    Tower_RapidFire,
    Tower_Splash,
    Tower_Heavy,
    Tower_Ray,
}

