using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    public Cell[,] VirtualSlotMatrix = null;

    public GameObject SlotGrid = null;

    public int row;

    public int column;

    private SlotGrid sg;

    [SerializeField] private Tower StandardTowerPrefab;

    [SerializeField] private Tower RapidFireTowerPrefab;

    [SerializeField] private Tower SplashTowerPrefab;

    [SerializeField] private Tower HeavyTowerPrefab;

    [SerializeField] private Tower RayTowerPrefab;

    [SerializeField] private GameObject towers = null;

    //private float buildtime = 0;

    private TowerFactory[] TowerFactoryArray = new TowerFactory[5];

    private bool canBuildTower = false;

    private int towerType = 0;

    private bool canSellTower = false;

    private int layermask = 0;

    // Start is called before the first frame update
    void Start()
    {
        layermask = LayerMask.GetMask("Graphics");
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

        TowerFactoryArray[0] = new TowerFactory(StandardTowerPrefab, towers);
        TowerFactoryArray[1] = new TowerFactory(RapidFireTowerPrefab, towers);
        TowerFactoryArray[2] = new TowerFactory(SplashTowerPrefab, towers);
        TowerFactoryArray[3] = new TowerFactory(HeavyTowerPrefab, towers);
        TowerFactoryArray[4] = new TowerFactory(RayTowerPrefab, towers);
    }

    // Update is called once per frame
    void Update()
    {
        //To do if build tower buttons pressed and wait or not pressed.
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (canBuildTower)
            {
                if (Physics.Raycast(ray, out hit))
                {
                    Transform objectHit = hit.transform;
                    int i = (int) objectHit.position.x;
                    int j = (int) objectHit.position.y;
                    if (VirtualSlotMatrix[i, j].getIsFilled() == false)
                    {
                        spawnTower(objectHit, i, j);
                    }
                    //else
                    //{
                        //to do spawn text to tell player, "you can't build here."
                    //}
                }
            }

            if (canSellTower)
            {
                if (Physics.Raycast(ray, out hit, 10f, layermask))
                {
                    Transform objectHit = hit.transform;
                    int i = (int) objectHit.position.x;
                    int j = (int) objectHit.position.y;
                    //to do get towers income at reduced income price.
                    bool notFilled = sellTower();
                    VirtualSlotMatrix[i, j].setIsFilled(notFilled);
                    Destroy(hit.transform.gameObject);
                    canSellTower = false;
                }
            }


        }
    }

    public void TowerBuildButton0Clicked()
    {
        canBuildTower = true;
        towerType = 0;
    }

    public void TowerBuildButton1Clicked()
    {
        canBuildTower = true;
        towerType = 1;
    }

    public void TowerBuildButton2Clicked()
    {
        canBuildTower = true;
        towerType = 2;
    }

    public void TowerBuildButton3Clicked()
    {
        canBuildTower = true;
        towerType = 3;
    }

    public void TowerBuildButton4Clicked()
    {
        canBuildTower = true;
        towerType = 4;
    }

    public void spawnTower(Transform coord, int i, int j)
    {
        
        TowerFactoryArray[towerType].setSpawnPoint(coord);
        Tower NewTower = (Tower) TowerFactoryArray[towerType].produce();
        VirtualSlotMatrix[i, j].setIsFilled(true);
        canBuildTower = false;
    }

    public void sellTowerButtonClicked()
    {
        canSellTower = true;
    }

    public bool sellTower()
    {
        return false;
    }

    public Cell[,] getVirtualSlotMatrix()
    {
        return VirtualSlotMatrix;
    }
}
