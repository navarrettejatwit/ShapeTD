using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotGrid : MonoBehaviour
{
    public GameObject SlotGraphic = null;
    
    //to do all Gameobject map stuff and matrix stuff go to Map Class
    //to more graphic matrixes for map 

    public GameObject Parent = null;

    public GameObject[,] SlotMatrix;
    
    private Cell[,] VirtualSlotMatrix;

    private int row;
    
    private int column;

    private TowerSpawner ts;

    // Start is called before the first frame update
    void Start()
    {
        SlotMatrix = new GameObject[row, column];
        ts = (TowerSpawner) GameObject.Find("TowerSpawner").GetComponent(typeof(TowerSpawner));
        VirtualSlotMatrix = ts.getVirtualSlotMatrix();
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {                                       
                Vector3 Position = new Vector3(i, j, -1);
                SlotMatrix[i, j] = Instantiate(SlotGraphic, Position, Quaternion.identity, Parent.transform);
            }
        }
		updateSlotGraphic();
    }

    // Update is called once per frame
    void Update()
    {
        updateSlotGraphic();
    }


    public void updateSlotGraphic()
    {
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                VirtualSlotMatrix[i, j] = ts.getVirtualSlotMatrix()[i, j];
            }
        }
    }

    public void setRow(int r)
    {
        row = r;
    }
    
    public void setColumn(int c)
    {
        
        column = c;
    }
    
}
