using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleScript : MonoBehaviour
{
    [SerializeField] private GameObject maze;
    [SerializeField] private GameObject finishLine;

    [SerializeField] private int turnSpeed;

    private void Start()
    {

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
            QuestManager.Instance.currentQuest.questComplete = true;
            SceneManager.LoadScene(0);
        }
    }
}
