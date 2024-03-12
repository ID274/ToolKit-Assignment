using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class MapMesh : MonoBehaviour
{
    [Header("NavMesh")]
    public NavMeshSurface navSurface;
    public GameObject navSurfaceHolder;

    void Start()
    {
        //navSurface.BuildNavMesh();
    }
}
