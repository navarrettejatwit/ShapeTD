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
                    Debug.Log("spawnedTower");
                }
            }

            if (canSellTower)
            {
                //handle accidentle press // needs more testing
                if (Physics.Raycast(ray, out hit, 10f, layermask))
                {
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
    }

    public void TowerBuildButtonClicked()
    {
        canBuildTower = true;
    }

    public void spawnTower(Transform coord, int i, int j)
    {
        Tower_Factory.setSpawnPoint(coord);
        Tower NewTower = (Tower) Tower_Factory.produce();
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
