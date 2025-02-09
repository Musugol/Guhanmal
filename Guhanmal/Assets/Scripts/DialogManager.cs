﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
	public TalkManager talkManger;
    public QuestManager questManger;
    public Animator talkPanel;
    public Animator portraitAnim;
    public Image portraitImg;
    public Sprite prevPortrait;
    public Text talkText;
    public Text questText;
    public GameObject menuSet;
    public GameObject scanObject;
    public GameObject player;
    public bool isAction;
    public int talkIndex;

    private void Start()
    {
        GameLoad();
        questText.text = questManger.CheckQuest();
    }

    void Update()
    {
        //Sub Menu
        if (Input.GetButtonDown("Cancel"))
        {
            if (menuSet.activeSelf)
                menuSet.SetActive(false);
            else
                menuSet.SetActive(true);
        }
    }
    public void Action(GameObject scanObj)
    {
        //Get Current Object
        scanObject = scanObj;
        ObjData objData = scanObject.GetComponent<ObjData>();
        Talk(objData.id, objData.isNpc);

		//Visible Talk for Action
        talkPanel.SetBool("isShow", isAction);
    }

    void Talk(int id, bool isNpc)
    {
        //Set Talk Data
        int questTallkIndex = questManger.GetQuestTalkIndex(id);
        string talkData = talkManger.GetTalk(id + questTallkIndex, talkIndex); //Set TalkData

        //End Talk
        if(talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            questText.text = questManger.CheckQuest(id);
            return;
        }
        //Continue Talk
        if (isNpc)
        {
            talkText.text = talkData.Split(':')[0]; //:를 통해 TalkManager의 대화내용과 초상화 인덱스 구분
            //Show Portrait
            portraitImg.sprite = talkManger.GetPortrait(id,int.Parse(talkData.Split(':')[1]));
            portraitImg.color = new Color(1, 1, 1, 1);
			//Animation Portrait
            if(prevPortrait != portraitImg.sprite)
            {
                portraitAnim.SetTrigger("doEffect");
                prevPortrait = portraitImg.sprite;
            }
        }
        else
        {
            talkText.text = talkData;
            portraitImg.color = new Color(1, 1, 1, 0);
        }

        isAction = true;
        talkIndex++;
    }
    public void GameSave()
    {
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
        PlayerPrefs.SetInt("QustId", questManger.questId);
        PlayerPrefs.SetInt("QustActionIndex", questManger.questActionIndex);
        PlayerPrefs.Save();

        menuSet.SetActive(false);
        //player.x 
        //
    }

    public void GameLoad()
    {
        if (!PlayerPrefs.HasKey("PlayerX"))
            return;

        float x =PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");
        int questId = PlayerPrefs.GetInt("QustId");
        int questActionIndex = PlayerPrefs.GetInt("QustActionIndex");

        player.transform.position = new Vector3(x, y, 0);
        questManger.questId = questId;
        questManger.questActionIndex = questActionIndex;
    }

    public void GameExit()
    {
        Application.Quit(); //빌드해서 확인
    }
}
