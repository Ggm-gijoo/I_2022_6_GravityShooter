using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int,string[]> talkData;

    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenData();
    }

    public void GenData()
    {
        talkData.Add(0, new string[] { "<b><size=75%> 여기는 팀 레인보우식스샌즈.\n달 점령 작전을 시행합니다. </size></b>", "<b> . </b>", "<b> . . </b>", "<b> . . . </b>", "<b><size=75%> 전방에 인증 코드 식별 불가능한 <color=#882200>로봇</color> 다수 확인됨. </size></b>", "<b><size=75%> 수월한 작전 진행을 위해 파괴를 시도합니다.</size></b>" });
        talkData.Add(100, new string[] { "<b><color=#ff6600>NPC1</color>\n</b><size=75%>있는가?</size>", "<b><color=#ff6600>NPC1</color>\n</b>난 있다네!" });
        talkData.Add(200, new string[] { "<b><color=#d3de8b>NPC2</color>\n</b><size=75%>안녕</size>", "<b><color=#d3de8b>NPC2</color>\n</b>행성을 망치는 로봇을 잡아줘!", "<b><color=#d3de8b>NPC2</color>\n</b>응 구라야~" });

    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length) return null;
        else return talkData[id][talkIndex];
    }
}
