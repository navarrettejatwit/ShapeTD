using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Tower : MonoBehaviour, Product
{


    public TowerType towerType;
    public bool isSpawned;

}




    public enum TowerType
    {
        Tower_Basic,
        Tower_SpeedShooter
    }

