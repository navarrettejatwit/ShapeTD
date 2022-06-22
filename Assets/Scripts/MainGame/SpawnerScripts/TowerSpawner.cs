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

    [SerializeField] private GameObject towers = null;

    //private float buildtime = 0;

    private TowerFactory Tower_Factory;

    private bool canBuildTower = false;

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

        Tower_Factory = new TowerFactory(TowerPrefab, towers);
    }

    // Update is called once per frame
    void Update()
    {
        //solve Highlight tower slot for mouse hover.
        //To do if build tower buttons pressed and wait or not pressed.
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (canBuildTower)
            {
                //RaycastHit hit;
                //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                //make a way for this paint mode not turn off until tower is place or cancelled.
                if (Physics.Raycast(ray, out hit))
                {
                    Transform objectHit = hit.transform;
                    int i = (int) objectHit.position.x;
                    int j = (int) objectHit.position.y;
                    bool fill = spawnTower(objectHit);
                    VirtualSlotMatrix[i, j].setIsFilled(fill);
                    Debug.Log("spawnedTower");
                    canBuildTower = false;
                }
            }

            if (canSellTower)
            {
                if (Physics.Raycast(ray, out hit, 10f, layermask))
                {
                    //make a way for this paint mode not turn off until tower is sold or cancellation.
                    Transform objectHit = hit.transform;
                    int i = (int) objectHit.position.x;
                    int j = (int) objectHit.position.y;
                    //to do get towers income at reduced income price.
                    bool notFilled = sellTower();
                    VirtualSlotMatrix[i, j].setIsFilled(notFilled);
                    Destroy(hit.transform.gameObject);
                    Debug.Log("SellTower");
                    canSellTower = false;
                }
            }


        }

        //if (Input.GetMouseButtonDown(1))
        //{
            //if (canSellTower)
            //{
                //RaycastHit hit;
                //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                //if (Physics.Raycast(ray, out hit))
                //{
                    //Transform objectHit = hit.transform;
                    //int i = (int) objectHit.position.x;
                    //int j = (int) objectHit.position.y;
                    //to do get towers income at reduced income price.
                    //bool notFilled = sellTower();
                    //VirtualSlotMatrix[i, j].setIsFilled(notFilled);
                    //Destroy(hit.transform.gameObject);
                    //Debug.Log("SellTower");
                    //canSellTower = false;
                //}
            //}
        //}

    }

    public void TowerBuildButtonClicked()
    {
        canBuildTower = true;
    }

    public bool spawnTower(Transform coord)
    {
        Tower_Factory.setSpawnPoint(coord);
        Tower NewTower = (Tower) Tower_Factory.produce();
        return true;
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
