using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class QuestNPC : MonoBehaviour, IPointerClickHandler
{
    public bool talked;
    [SerializeField] private GameObject dialogueMenu;
    [SerializeField] private DialogueScript dialogueScript;

    // Start is called before the first frame update
    void Start()
    {
        talked = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("OnPointerClick");
        dialogueMenu.SetActive(true);
        dialogueScript.dialogueID = 0;
    }

}
