using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleScript : MonoBehaviour
{
    [SerializeField] private Camera puzzleCamera;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject maze;
    [SerializeField] private GameObject finishLine;

    [SerializeField] private int turnSpeed;

    private void Awake()
    {
        mainCamera.enabled = true;
        puzzleCamera.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKey("a"))
        {
            maze.transform.eulerAngles += new Vector3(0, 0, turnSpeed * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            maze.transform.eulerAngles -= new Vector3(0, 0, turnSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == finishLine)
        {
            QuestManager.Instance.NextQuest();
            mainCamera.enabled = true;
            puzzleCamera.enabled = false;
        }
    }
}
