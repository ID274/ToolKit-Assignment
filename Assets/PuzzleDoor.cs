using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleDoor : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (QuestManager.Instance.currentQuestID == 2)
        {
            SceneManager.LoadScene(1);
        }
    }
}
