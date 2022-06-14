using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    //private List<Tower> allTowers = new List<Tower>();
    
    

    [SerializeField] private Tower towerPrefab = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;
                int i = (int) objectHit.position.x;
                int j = (int) objectHit.position.y;
                //int newValue = placeTower(i, j);
                //slotMatrix[i, j].setState(newValue);
            }
        }

        if (Input.GetMouseButtonDown(2))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;
                int i = (int) objectHit.position.x;
                int j = (int) objectHit.position.y;
                //int newValue = sellTower(i, j);
                //slotMatrix[i, j].setState(newValue);
            }
        }
        
    }
}
