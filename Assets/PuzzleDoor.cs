using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleDoor : MonoBehaviour
{
    [SerializeField] private Camera puzzleCamera;
    [SerializeField] private Camera mainCamera;
    private void OnCollisionEnter(Collision collision)
    {
        if (QuestManager.Instance.currentQuestID == 2)
        {
            puzzleCamera.enabled = true;
            mainCamera.enabled = false;
        }
    }
}
