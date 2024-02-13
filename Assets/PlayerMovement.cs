using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Camera mainCamera;
    [SerializeField] private NavMeshAgent player;
    [SerializeField] private MapGenerator mapGenerator;

    private Vector3 cameraOffset;

    // Start is called before the first frame update
    void Start()
    {
        player = this.GetComponent<NavMeshAgent>();
        if (mapGenerator != null && mapGenerator.spawnPoint != null)
        {
            transform.position = new Vector3(mapGenerator.spawnPoint.position.x + 1, 1, mapGenerator.spawnPoint.position.z + 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        cameraOffset = new Vector3(transform.position.x - 3, transform.position.y + 18.5f, transform.position.z);
        if (mainCamera.transform.position != cameraOffset)
        {
            mainCamera.transform.position = cameraOffset; // Keep camera on player
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitPoint;

            if (Physics.Raycast(ray, out hitPoint))
            {
                if (!player.isOnNavMesh)
                {
                    player.enabled = false;
                    player.enabled = true;
                }
                player.SetDestination(hitPoint.point);
                
            }
        }
    }
}
