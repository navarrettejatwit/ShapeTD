using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyPop : MonoBehaviour { 
public GameObject enemyContainer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<UnityEngine.UI.Text>().text = "Enemies: " + enemyContainer.transform.childCount;
    }
    
    void Awake()
    {
        enemyContainer = GameObject.Find("Enemies");
    }
}
