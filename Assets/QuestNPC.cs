using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class QuestNPC : MonoBehaviour
{
    public bool talked;
    [SerializeField] private GameObject dialogueMenu;
    [SerializeField] private DialogueScript dialogueScript;
    [SerializeField] private Image[] menus;
    [SerializeField] private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        dialogueScript = dialogueMenu.GetComponent<DialogueScript>();
        talked = false;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var Image in menus)
        {
            if (Image.IsActive() == true)
            {
                return;
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitPoint;

            if (Physics.Raycast(ray, out hitPoint) && hitPoint.transform.name == this.name)
            {
                dialogueMenu.SetActive(true);
                if (QuestManager.Instance.complete)
                {
                    dialogueScript.OnQuestComplete();
                }
                
            }
        }
    }

}
