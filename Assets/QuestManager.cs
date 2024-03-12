using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance { get; private set; }

    [Header("Quest Manager")]
    public int currentQuestID;
    public Quest currentQuest;
    [SerializeField] private Quest[] quests;
    public QuestNPC questNPC;


    [Header("Quest Display")]
    [SerializeField] private TextMeshProUGUI questNameText;
    [SerializeField] private TextMeshProUGUI questDescriptionText;

    // Start is called before the first frame update
    void Start()
    {
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
        if (questNPC.talked)
        {
            NextQuest();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (quests[currentQuestID] != null && currentQuest != quests[currentQuestID])
        {
            currentQuest = quests[currentQuestID];
            Debug.Log(currentQuest.ToString());
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

    void NextQuest()
    {
        if (quests[currentQuestID] != null && currentQuest != quests[currentQuestID])
        {
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
        currentQuestID++;
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
