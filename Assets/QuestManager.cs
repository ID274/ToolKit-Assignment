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
        NextQuest();
    }

    // Update is called once per frame
    void Update()
    {
        if (quests[currentQuestID - 1] != null && currentQuest != quests[currentQuestID - 1])
        {
            currentQuest = quests[currentQuestID - 1];
            Debug.Log(currentQuest.ToString());
        }
        else
        {
            return;
        }
        if (currentQuest.questComplete)
        {
            EndQuest();
        }
    }

    void NextQuest()
    {
        currentQuestID++;
        if (quests[currentQuestID - 1] != null && currentQuest != quests[currentQuestID - 1])
        {
            currentQuest = quests[currentQuestID - 1];
            Debug.Log(currentQuest.ToString());
        }
        else
        {
            return;
        }
        DisplayQuest();
    }

    void EndQuest()
    {
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
