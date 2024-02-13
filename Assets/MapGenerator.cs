using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [Header("Prefabs (each object in the array has the same chance of spawning)")]
    [SerializeField] private GameObject[] blockPrefabs;

    [SerializeField] private GameObject floorBoundaryBlock;

    [Header("Map Settings")]
    [SerializeField] private int mapHeight;
    [SerializeField] private int mapWidth;
    [SerializeField] private bool makeMapOnStart = false;
    [SerializeField] public bool spawnPlants = false;


    void Start()
    {
        if (makeMapOnStart)
        {
            for (int i = 0; i < mapHeight; i++)
            {
                int rnd = Random.Range(0, blockPrefabs.Length);
                GameObject zBlock = Instantiate(blockPrefabs[rnd], new Vector3(0, 0, i), Quaternion.identity);
                PlantScript plantzBlock = zBlock.GetComponent<PlantScript>();
                if (plantzBlock != null)
                {
                    plantzBlock.spawnPlantsLocal = spawnPlants;
                }
                GameObject zboundaryBlock = Instantiate(floorBoundaryBlock, new Vector3(0, -0.9f, i), Quaternion.identity);
                for (int j = 1; j < mapWidth; j++)
                {
                    GameObject xBlock = Instantiate(blockPrefabs[rnd], new Vector3(j, 0, i), Quaternion.identity);
                    PlantScript plantxBlock = xBlock.GetComponent<PlantScript>();
                    if (plantxBlock != null)
                    {
                        plantxBlock.spawnPlantsLocal = spawnPlants;
                    }
                    GameObject xboundaryBlock = Instantiate(floorBoundaryBlock, new Vector3(j, -0.9f, i), Quaternion.identity);
                    rnd = Random.Range(0, blockPrefabs.Length);
                }
                
            }
        }
        
    }
}
