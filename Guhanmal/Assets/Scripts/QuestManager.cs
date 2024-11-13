using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public int questActionIndex;
    public GameObject[] questObject;
    Dictionary<int, QuestData> questList;
    
    void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }

    void GenerateData()
    {
        questList.Add(10, new QuestData("살인사건 조사", new int[] { 1000, 200 })); //{시작npc넘버, 다음npc넘버}
		questList.Add(20, new QuestData("살인사건의 전말", new int[] { 2000, 100, 3000 }));
		questList.Add(30, new QuestData("퀘스트 올 클리어!", new int[] { 0 })); //마무리 퀘스트
    }

    public int GetQuestTalkIndex(int id)
    {
        return questId + questActionIndex;
    }

    public string CheckQuest(int id)
    {
        //Next Talk Target
        if (id == questList[questId].npcId[questActionIndex])
            questActionIndex++;

        ControlObject();
        //Talk Complete& Next Quest
        if (questActionIndex == questList[questId].npcId.Length)
            NextQuest();

        //Quest Name
        return questList[questId].questName;
    }

    public string CheckQuest()
    {
        //Quest Name
        return questList[questId].questName;
    }

    void NextQuest()
    {
        questId += 10;
        questActionIndex = 0;
    }

    void ControlObject()
    {
        switch (questId)
        {
            case 10:
                if (questActionIndex == 1)
                    questObject[0].SetActive(false);
                break;
            case 20:
                if(questActionIndex == 2)
                    questObject[0].SetActive(true);
                break;

        }
    }
}
