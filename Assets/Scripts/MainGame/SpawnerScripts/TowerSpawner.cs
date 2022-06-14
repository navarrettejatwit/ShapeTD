using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    //private List<Tower> allTowers = new List<Tower>();

    public Cell[,] VirtualSlotMatrix = null;

    public GameObject SlotGrid = null;

    public int row;
    
    public int column;

    private SlotGrid sg;
    
    [SerializeField] private Tower TowerPrefab;

    private float buildtime = 0;

    private TowerFactory Tower_Factory;
    
    // Start is called before the first frame update
    void Start()
    {
        VirtualSlotMatrix = new Cell[row, column];
        sg = SlotGrid.GetComponent<SlotGrid>();
        sg.setRow(row);
        sg.setColumn(column);
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                VirtualSlotMatrix[i, j] = new Cell(i, j, false);
            }
        }
        Tower_Factory = new TowerFactory(TowerPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        //To do if build tower buttons pressed and wait or not pressed.
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;
                int i = (int) objectHit.position.x;
                int j = (int) objectHit.position.y;
                bool fill = spawnTower(objectHit);
                VirtualSlotMatrix[i, j].setIsFilled(fill);
                //To do mark that tower was placed mouse input set disabled
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
                bool notFilled = sellTower(objectHit);
                VirtualSlotMatrix[i, j].setIsFilled(notFilled);
            }
        }
        
    }

    public bool spawnTower(Transform coord)
    {
        Tower_Factory.setSpawnPoint(coord);
        Tower NewTower = (Tower) Tower_Factory.produce();
        return true;
    }

    public bool sellTower(Transform coord)
    {
        //To Do//Tower Destroy Method Call; //During Restart All Towers Must Be Destroyed
        return false;
    }

    public Cell[,] getVirtualSlotMatrix()
    {
        return VirtualSlotMatrix;
    }
}
