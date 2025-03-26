using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;
    public List<Quest> questList = new List<Quest>();

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void AddQuest(Quest quest)
    {
        questList.Add(quest);
        Debug.Log($"Thêm nhiệm vụ mới: {quest.questName}");
    }

    public void EnemyKilled(string questName)
    {
        Quest quest = questList.Find(q => q.questName == questName);
        if (quest != null)
        {
            quest.UpdateProgress();
        }
    }
}

