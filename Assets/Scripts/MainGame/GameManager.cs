using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static GameManager _instance = null;

    [SerializeField] private GameObject graphTile = null;

    [SerializeField] private GameObject graphTile1 = null;
    
    [SerializeField] private GameObject MapContainer = null;

    [SerializeField] private Camera camera;

    [SerializeField] private int row;

    [SerializeField] private int column;

    public GameObject[,] map;
    
    private float aspectRatio;

    private float previousAspectRatio;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    public static GameManager instance()
    {
        return _instance;
    }
    // Start is called before the first frame update
    void Start()
    {
        map = new GameObject[row, column];
        bool makeGreen = false;
        
        for (int i = 0; i < row; i++)
        {
            // Start for Row
            if (makeGreen) makeGreen = false;
            else makeGreen = true;
            
            for (int j = 0; j < column; j++)
            {
                //Start for Column
                Vector3 Position = new Vector3(i, j, 0);
                if (makeGreen)
                {
                    map[i, j] = Instantiate(graphTile1, Position, Quaternion.identity, MapContainer.transform);
                    makeGreen = false;
                }
                else
                {
                    map[i, j] = Instantiate(graphTile, Position, Quaternion.identity, MapContainer.transform);
                    makeGreen = true;
                }

                map[i, j].transform.rotation = Quaternion.Euler(new Vector3(270, 0, 0));
            }
        }

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
