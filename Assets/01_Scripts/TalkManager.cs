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
        talkData.Add(100, new string[] { "<b><color=#ff6600>��Űȣ��</color>\n</b><color=#ffff00>������</color> ������ ���� �ִ°�?", "�� �ִٳ�!" });
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length) return null;
        else return talkData[id][talkIndex];
    }
}
