using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueScript : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private GameObject dialogueMenu;
    [SerializeField] private Image speakerSprite;
    [SerializeField] private TextMeshProUGUI speakerNameText;
    [SerializeField] private TextMeshProUGUI speakerDialogueText;
    [SerializeField] private Button closeButton;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button choice1Button;
    [SerializeField] private Button choice2Button;

    [Header("References")]
    [SerializeField] private QuestNPC questNPC;

    [Header("Attributes")]
    public int dialogueID;
    public string dialogueText;
    public TextMeshProUGUI choice1Text;
    public TextMeshProUGUI choice2Text;

    [Header("Show Text Attributes")]
    [SerializeField] private string currentText = "";
    [SerializeField] private float delay = 0.1f;
    [SerializeField] private float delayStart;


    [Header("Dialogue Contents")]
    [SerializeField] private string[] dialogueContent;
    [SerializeField] private string[] dialogueChoice1;
    [SerializeField] private string[] dialogueChoice2;



    private void OnEnable()
    {
        delayStart = delay;
        dialogueText = dialogueContent[dialogueID];
        StartCoroutine(ShowText());
    }

    private void Update()
    {
        if (dialogueID == 0)
        {
            speakerNameText.text = "[QUEST NPC]";
        }
    }

    IEnumerator ShowText()
    {
        choice1Text.text = dialogueChoice1[dialogueID];
        choice2Text.text = dialogueChoice2[dialogueID];
        for (int i = 0; i < dialogueText.Length + 1; i++)
        {
            currentText = dialogueText.Substring(0, i);
            speakerDialogueText.text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }

    public void OnChoiceOne()
    {
        if (dialogueID == 0 && QuestManager.Instance.currentQuestID == 0)
        {
            questNPC.talked = true;
            delay = delayStart;
            dialogueMenu.SetActive(false);
        }
        else if (dialogueID == 1)
        {
            delay = delayStart;
            dialogueMenu.SetActive(false);
            QuestManager.Instance.EndQuest();
        }
    }
    public void OnChoiceTwo()
    {
        if (dialogueID == 0 && QuestManager.Instance.currentQuestID == 0)
        {
            delay = delayStart;
            dialogueMenu.SetActive(false);
        }
        else if (dialogueID == 1)
        {
            delay = delayStart;
            dialogueMenu.SetActive(false);
            QuestManager.Instance.EndQuest();
        }
    }

    public void OnNextButton()
    {
        delay = 0.01f;
    }

    public void OnCloseButton()
    {
        delay = delayStart;
        dialogueMenu.SetActive(false);
    }

    public void OnQuestComplete()
    {
        dialogueID++;
        choice1Text.text = dialogueChoice1[dialogueID];
        choice2Text.text = dialogueChoice2[dialogueID];
        dialogueText = dialogueContent[dialogueID];
    }

}
