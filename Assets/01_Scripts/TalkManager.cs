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
        talkData.Add(0, new string[] { "<b><size=75%> ����� �� ���κ���Ľ�����.\n�� ���� ������ �����մϴ�. </size></b>", "<b> . </b>", "<b> . . </b>", "<b> . . . </b>", "<b><size=75%> ���濡 ���� �ڵ� �ĺ� �Ұ����� <color=#882200>�κ�</color> �ټ� Ȯ�ε�. </size></b>", "<b><size=75%> ������ ���� ������ ���� �ı��� �õ��մϴ�.</size></b>" });
        talkData.Add(100, new string[] { "<b><color=#ff6600>NPC1</color>\n</b><size=75%>�ִ°�?</size>", "<b><color=#ff6600>NPC1</color>\n</b>�� �ִٳ�!" });
        talkData.Add(200, new string[] { "<b><color=#d3de8b>NPC2</color>\n</b><size=75%>�ȳ�</size>", "<b><color=#d3de8b>NPC2</color>\n</b>�༺�� ��ġ�� �κ��� �����!", "<b><color=#d3de8b>NPC2</color>\n</b>�� �����~" });

    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length) return null;
        else return talkData[id][talkIndex];
    }
}
