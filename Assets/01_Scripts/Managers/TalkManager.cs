using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Sheet
{
    public string content;
    public string end;
}

public class TalkManager : MonoBehaviour
{
    Dictionary<int,string[]> talkData;
    GameObject abc;
    string[] adad = { "<size=75%> 안녕 </size>" };

    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenData();
    }

    public void GenData()
    {
        talkData.Add(0, new string[] { "서기 5억2천만년","<size=75%>" +  "현 시각 태양력 17:09,\n행성 개발 시퀀스를 시작합니다." + "</size>", " . . . ", "<size=75%>" + "전방에 인증 코드 식별 불가능한 <color=aqua>로봇</color>이 다수 확인됨." + "</size>", "<size=75%> 수월한 작전 진행을 위해 파괴를 시도합니다.</size>" });
        talkData.Add(100, new string[] { "<size=75%>이것은 대단한 것이 나올 것이 분명한 보물상자일 것이다.</size>", " . . . ", "<size=150%> 이럴수가!!!!! </size>", " 그다지 쓸만한 것은 없었다." });
        talkData.Add(200, new string[] { "<color=#d3de8b>NPC2</color>\n<size=75%>안녕</size>", "<color=#d3de8b>NPC2</color>\n꿈이 있는가?", "<color=#d3de8b>NPC2</color>\n난 있다네!" });
        talkData.Add(1000, new string[] { "이것은 과거 거주장소 역할을 했을 것으로 추정된다.", "과거 지적 생명체가 존재했음을 확인할 수 있다.", "내부에 로봇이 드글드글한 것으로 인식된다." });
        talkData.Add(1001, adad);
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length) return null;
        else return talkData[id][talkIndex];
    }
}
