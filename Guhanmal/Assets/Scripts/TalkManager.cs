using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;

    public Sprite[] portraitArr;
    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    void GenerateData()
    {
        talkData.Add(1000, new string[] { "흐음... : 1"});
        talkData.Add(100, new string[] { "오 씨의 집이다" });
        talkData.Add(200, new string[] { "저잣거리 입구에 있는 장승이다." });
		talkData.Add(500, new string[] { "오 씨의 집이 아닌 것 같다..." });
		talkData.Add(2000, new string[] { "(수군수군...) : 3" });
		talkData.Add(3000, new string[] { "크흠... : 3" });


		//여기부터 QuestTalk
		//Event1 박재석의 실종과 사라진 증서
		talkData.Add(10 + 1000, new string[] { "재석 동지가 아직 오지 않았습니다.: 0", "무슨 일이 생긴 것 같습니다. : 0",
		"재석 동지에게 무슨 일이 생긴 것 같구나. : 1", "재석 동지에게 폐하의 직인이 찍힌 내 어음증서가 있는데… 그것이 왜놈들 손에 넘어가면 큰 일이 날 것이야…: 1",
		"사혁, 자네가 증서를 찾아봐 줄 수 있겠나?: 1", "알겠습니다. : 0"});

        talkData.Add(11 + 200, new string[] { "저기에 사람들이 많이 모여있군...", "가서 물어볼까?" });
        talkData.Add(20 + 2000, new string[] { "마을에서 살인사건이 일어났다네요! : 3 ","나도 그 소문 들었네...! :1",
		"옆집에 오 씨가 그 장면을 목격했다고 그렇게 소문을 내고 다니던데...: 2",
		"잠깐, 그게 무슨 일인지 말해 줄 수 있겠소?:0",
		"(머뭇거리며) 옆집의 오 씨가 살인사건을 목격했다는구만:2",
		"고맙소! : 0", "오 씨의 집을 찾아봐야겠군... : 0"  });
        talkData.Add(21 + 100, new string[] { "여기가 오 씨의 집인가?", "아무도 없는 것 같은데...","아 마침 오 씨가 저기 오는군..." });
        talkData.Add(22 + 3000, new string[] { "자네가 살인사건을 목격했다고 하는데 나에게 이야기 해줄 수 있는가?? : 0",
		"이야기 해줄 수는 있지만 맨입으로는 할 수 없지 : 3", "내 부탁을 들어주면 전부 이야기해 주겠네 : 3", "무슨 부탁이오? : 0", "실은 얼마 전에 왜놈들이 내 물건을 가져갔는데...:3","그 물건좀 찾아와 주게 :3"});

		//Event2 목격자와의 접촉
		//talkData.Add(20 + 2000, new string[] { "뭐지...? : 0", "이보시오! 잠시만 기다려주시오!! : 0" });

		/*
		//Event3 범인의 지목
		talkData.Add(30 + 1000, new string[] { "이봐요! 왜 그렇게 도망갑니까? : 0",
		"혹시 내가 수소문 하는 사건에 대해 알고있는겁니까? : 0",
		"저...그... 그게 저는 아무것도 몰라요...! : 3",
		"당신 뭔가 알고 있는거 아니오? 나쁜 사람 아니니 말해주시오. : 0",
		"어떤 해도 끼치지 않겠소 : 0",
		"...사...사실.. 어제 흑룡회 일당이... : 3",
		"어떤 사람을 죽이고 죽은 사람 품에서 무엇을 꺼내가는 것을 봤소...:3",
		"저는 정말 그것 밖에 못봤습니다!! 살려주시오!! : 3",
		"(흑룡회 자식들이 왜...?) : 0",
		"고맛소. 그 장소가 어딘지 알려줄 수 있겠소? : 0",
		"조용히 따라오시오... : 3"});

		//Event4 살인 현장
		talkData.Add(31 + 4000, new string[] { "이 곳이오... 으윽..! 잔인하기도 하지... : 3",
		"(!!!!) : 0", "아.. 아니 재석 동지...! 어떻게 이럴수가... 흑룡회 이 자식들...! 가만두지 않겠어!!! : 0",
		"정말 흑룡회의 소행이 확실합니까? : 0",
		"맞소, 내 두 눈으로 똑똑히 보았소 : 3",
		"정말 고맙소. 언젠간 이 은혜를 꼭 갚으리다. : 0"});		 
		 */


		portraitData.Add(1000 + 0, portraitArr[0]);
        portraitData.Add(1000 + 1, portraitArr[1]);
        portraitData.Add(1000 + 2, portraitArr[2]);
        portraitData.Add(1000 + 3, portraitArr[3]);

		portraitData.Add(2000 + 0, portraitArr[4]);
        portraitData.Add(2000 + 1, portraitArr[5]);
        portraitData.Add(2000 + 2, portraitArr[6]);
        portraitData.Add(2000 + 3, portraitArr[7]);

		portraitData.Add(3000 + 0, portraitArr[8]);
		portraitData.Add(3000 + 1, portraitArr[9]);
		portraitData.Add(3000 + 2, portraitArr[10]);
		portraitData.Add(3000 + 3, portraitArr[11]);


	}

    public string GetTalk(int id, int talkIndex)
    {
        if (!talkData.ContainsKey(id))
        {
            if (!talkData.ContainsKey(id - id % 10))
                return GetTalk(id - id % 100, talkIndex); //Get First Talk
            else
                return GetTalk(id - id % 10, talkIndex); //Get First Quest Talk
        }
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }

    public Sprite GetPortrait(int id, int portraitIndex)
    {
        return portraitData[id + portraitIndex];
    }
}
