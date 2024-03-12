using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance { get; private set; }

    [Header("Quest Manager")]
    public int currentQuestID;
    public Quest currentQuest;
    [SerializeField] private Quest[] quests;
    public QuestNPC[] questNPC;
    public GameObject[] NPC;
    public bool complete;
    [SerializeField] private Item currentItem;


    [Header("Quest Display")]
    [SerializeField] private TextMeshProUGUI questNameText;
    [SerializeField] private TextMeshProUGUI questDescriptionText;

    // Start is called before the first frame update
    void Start()
    {
        questNPC[0] = NPC[0].GetComponent<QuestNPC>();
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        questNameText.text = "";
        questDescriptionText.text = "";
        currentQuestID = 0;
        QuestBeginning();
        DisplayQuest();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentQuest.item != null && currentItem != currentQuest.item)
        {
            currentItem = currentQuest.item;
        }
        if (questNPC[0].talked)
        {
            Debug.Log("QuestNPC talked");
            questNPC[0].talked = false;
            NextQuest();
        }
        if (quests[currentQuestID] != null)
        {
            currentQuest = quests[currentQuestID];
            //Debug.Log(currentQuest.ToString());
        }
        else
        {
            return;
        }
        //if (currentQuest.questComplete)
        //{
        //    EndQuest();
        //}
    }

    public void QuestBeginning()
    {
        if (quests[currentQuestID] != null && currentQuestID == 0)
        {
            currentQuest = quests[currentQuestID];
            DisplayQuest();
        }
    }

    public void NextQuest()
    {
        complete = false;
        if (quests[currentQuestID + 1] != null)
        {
            currentQuestID++;
            currentQuest = quests[currentQuestID];
            Debug.Log(currentQuest.ToString());
        }
        else
        {
            return;
        }
        DisplayQuest();
    }

    public void EndQuest()
    {
        Debug.Log("Check1");
        if (currentQuest.item != null)
        {
            Debug.Log("Check2");
            currentItem.count++;
            InventoryManager.Instance.Add(currentItem);
        }

        InventoryManager.Instance.ListItems();
        NextQuest();
    }

    void DisplayQuest()
    {
        Debug.Log(currentQuest.ToString());
        Debug.Log($"{currentQuest.questName}");
        Debug.Log($"{currentQuest.questDescription}");
        questNameText.text = currentQuest.questName;
        questDescriptionText.text = currentQuest.questDescription;
    }
}
