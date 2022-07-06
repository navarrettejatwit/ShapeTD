using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    private static GameManager _instance = null;
    
    [SerializeField] private GameObject[] TileArray = new GameObject [10];
    
    [SerializeField] private GameObject[] TileArray1 = new GameObject [10];

    [SerializeField] private GameObject graphTile2 = null;

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

    public Player player;
    public TextMeshProUGUI playText;


    public void updatePlayerHealth(int health)
    {

        if (health > 0)
        {
            playText.text = "Health: x" + health;
        }
        else playText.text = "0";

    }

    // Start is called before the first frame update
    void Start()
    {
        map = new GameObject[row, column];
        bool makeGreen = false;
        GameObject graphTile;

        for (int i = 0; i < row; i++)
        {
            // Start for Row
            if (makeGreen) makeGreen = false;
            else makeGreen = true;
            
            for (int j = 0; j < column; j++)
            {
                //Start for Column
                Vector3 Position = new Vector3(i, j, 0);
                if (j == 0) map[i, j] = Instantiate(graphTile2, Position, Quaternion.identity, MapContainer.transform);
                if (j == column - 1) map[i, j] = Instantiate(graphTile2, Position, Quaternion.identity, MapContainer.transform);
                if (makeGreen && j > 0 && j < row-1)
                {
                    graphTile = spawnDecorTile(makeGreen);
                    map[i, j] = Instantiate(graphTile, Position, Quaternion.identity, MapContainer.transform);
                    makeGreen = false;

                }
                else if (!makeGreen && j > 0 && j < row-1)
                {
                    graphTile = spawnDecorTile(makeGreen);
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

        //player.Reset();
      

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
    
    private GameObject spawnDecorTile(bool makeGreen)
    {
        GameObject Tile;
        int i = 0;
        if (makeGreen)
        {
            i = Random.Range(0, TileArray.Length);
            Tile = TileArray[i];

        }
        else
        {
            i = Random.Range(0, TileArray1.Length);
            Tile = TileArray1[i];
        }
        return Tile;
    }
    
}
