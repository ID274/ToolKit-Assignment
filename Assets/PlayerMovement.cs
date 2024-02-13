using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Camera mainCamera;

    private Vector3 cameraOffset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cameraOffset = new Vector3(transform.position.x - 3, transform.position.y + 18.5f, transform.position.z);
        if (mainCamera.transform.position != cameraOffset)
        {
            mainCamera.transform.position = cameraOffset; // Keep camera on player
        }
        if (transform.rotation.x != 0 || transform.rotation.z != 0)
        {
            transform.rotation = new Quaternion (0, transform.rotation.y, 0, 0); // Stabilises the player
        }
    }
}
