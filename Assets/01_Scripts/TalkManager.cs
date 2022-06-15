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
        talkData.Add(100, new string[] { "<b><color=#ff6600>돈키호테</color>\n</b><color=#ffff00>관리자</color> 나리는 꿈이 있는가?", "난 있다네!" });
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length) return null;
        else return talkData[id][talkIndex];
    }
}
