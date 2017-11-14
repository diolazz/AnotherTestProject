using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnManager : Singleton<SpawnManager>
{
    public GameObject[] polygonPrefabs;
    public int startAmountOfPolygons = 15;
    //spawn positions ?? depends on map size 
    //todo add struct for this constants
    public float xMin;
    public float yMin;
    public float xMax;
    public float yMax;
    
    private Transform polygonHolder;
    private string holdingName = "Polygons";
    
    void Start()
    { 
        //polygonHolder = GameObject.Find(holdingName).transform;
        CreatePoolOfPolygon();
        StartSpawn();
    }

    void CreatePoolOfPolygon()
    {
        for (int i = 0; i < polygonPrefabs.Length; i++)
        {
            PoolManager.Instance.CreatePool(polygonPrefabs[i], startAmountOfPolygons);
        }
    }

    void StartSpawn()
    {
        for (int i = 0; i < startAmountOfPolygons; i++)
        {
            SpawnPolygon();
        }
    }

    void SpawnPolygon()
    {
        PoolManager.Instance.ReuseObject(polygonPrefabs[RandomPolygon()], RandomPosition(), Quaternion.identity);
    }

    public void SpawnPolygon(PolygonType type)
    {
        PoolManager.Instance.ReuseObject(polygonPrefabs[(int)type], RandomPosition(), Quaternion.identity);
    }

    Vector2 RandomPosition()
    {
        float randomX = Random.Range(xMin, xMax);
        float randomY = Random.Range(yMin, yMax);

        return new Vector2(randomX, randomY);
    }

    int RandomPolygon()
    {
        return Random.Range(0, polygonPrefabs.Length);
    }
}