using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotGrid : MonoBehaviour
{
    public GameObject SlotGraphic = null;

    public GameObject Parent = null;

	public Camera camera;
    
    public GameObject[,] SlotMatrix;
    
    private Cell[,] VirtualSlotMatrix;

    private int row;
    
    private int column;

    private TowerSpawner ts;

	private float aspectRatio;

	private float previousAspectRatio;
    
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
                Vector3 Position = new Vector3(i, j, 0);
                SlotMatrix[i, j] = Instantiate(SlotGraphic, Position, Quaternion.identity, Parent.transform);
            }
        }
		updateSlotGraphic();
		Vector3 position = new Vector3((column - 1) / 2f, (row - 1) / 2f, -10);
		camera.transform.position = position;
		aspectRatio = camera.aspect;
		previousAspectRatio = aspectRatio;
		if (camera.orthographic){
			setCameraSize();
		}
    }

    // Update is called once per frame
    void Update()
    {
		if(camera.orthographic && camera.aspect != previousAspectRatio){
			aspectRatio = camera.aspect;
			previousAspectRatio = aspectRatio;
			setCameraSize();
		}
        updateSlotGraphic();
    }


    public void updateSlotGraphic()
    {
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                VirtualSlotMatrix[i, j] = ts.getVirtualSlotMatrix()[i, j];
                //To Do// slot graphic
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

	private void setCameraSize()
	{
		float rowBased = row / 2f;
		float columnBased = column / (2f * camera.aspect);
		camera.orthographicSize = Mathf.Max(rowBased, columnBased);
	}
}
