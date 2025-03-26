using UnityEngine;
using System.Collections.Generic;

public enum QuestStatus
{
    Pending,       // Chưa nhận nhiệm vụ
    InProgress,    // Đang thực hiện nhiệm vụ
    Completed      // Đã hoàn thành nhiệm vụ
}
[System.Serializable]
public class Quest
{
    public string questName;
    public string description;
    public int targetSlimeCount; // Số lượng Slime cần tiêu diệt
    public int currentSlimeCount; // Số lượng Slime đã tiêu diệt
    public bool isCompleted;
    public QuestStatus status;
    public int rewardXP;

    public Quest(string name, string desc, int target, int xp)
    {
        questName = name;
        description = desc;
        targetSlimeCount = target;
        currentSlimeCount = 0;
        rewardXP = xp;
        status = QuestStatus.Pending;
    }

    public void StartQuest()
    {
        status = QuestStatus.InProgress;
        Debug.Log($"Bắt đầu nhiệm vụ: {questName}");
    }

    public void UpdateProgress()
    {
        if (status == QuestStatus.InProgress)
        {
            currentSlimeCount++;
            Debug.Log($"Đã tiêu diệt {currentSlimeCount}/{targetSlimeCount} Slime");

            if (currentSlimeCount >= targetSlimeCount)
            {
                CompleteQuest();
            }
        }
    }

    public void CompleteQuest()
    {
        status = QuestStatus.Completed;
        Debug.Log($"Hoàn thành nhiệm vụ: {questName}. Nhận {rewardXP} XP!");
    }
}

