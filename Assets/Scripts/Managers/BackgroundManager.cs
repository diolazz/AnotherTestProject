using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : Singleton<BackgroundManager>
{
    [SerializeField] private int sizeX = 40;
    [SerializeField] private int sizeY = 40;
    [SerializeField] private Vector3 startPoint = new Vector3(-40f,-40f,0f);

    [SerializeField] private GameObject tilePrefab;
    
    private Transform tileHolder;
    private string tileHolderName = "Map";


    void Start()
    {
    //    GenerateMap();
    }

    public void GenerateMap()
    {
        tileHolder = new GameObject(tileHolderName).transform;

        for (int i = 0; i < sizeX+1; i++)
        {
            for (int j = 0; j < sizeY+1; j++)
            {
                GameObject newTile = Instantiate(tilePrefab, new Vector3(i, j, 0f) + startPoint, Quaternion.identity);
                newTile.transform.SetParent(tileHolder);
            }
        }
    }
}
