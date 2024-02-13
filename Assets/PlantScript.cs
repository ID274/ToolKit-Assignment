using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantScript : MonoBehaviour
{
    [SerializeField] private GameObject tree, bush;

    public bool spawnPlantsLocal;


    void Start()
    {
        tree.SetActive(false);
        bush.SetActive(false);
        if (spawnPlantsLocal)
        {
            TrySpawn();
        }
    }

    void TrySpawn()
    {
        int rnd = Random.Range(0, 50);
        if (rnd < 2)
        {
            SpawnTree();
        }
        else if (rnd < 7 && bush != null)
        {
            SpawnBush();
        }
    }

    void SpawnTree()
    {
        tree.SetActive(true);
    }
    void SpawnBush()
    {
        bush.SetActive(true);
    }

}
