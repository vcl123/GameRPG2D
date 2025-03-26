using UnityEngine;

public class NPCQuestGiver : MonoBehaviour
{
    public Quest newQuest;

    private void Start()
    {
        newQuest = new Quest("Tiêu diệt 5 Slime", "Hãy tiêu diệt 5 con Slime!", 5, 200);
    }

    public void GiveQuest()
    {
        if (QuestManager.instance != null)
        {
            QuestManager.instance.AddQuest(newQuest);
            newQuest.StartQuest();
        }
    }
}
