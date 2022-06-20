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
    string[] adad = { "<size=75%> �ȳ� </size>" };

    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenData();
    }

    public void GenData()
    {
        talkData.Add(0, new string[] { "���� 5��2õ����","<size=75%>" +  "�� �ð� �¾�� 17:09,\n�༺ ���� �������� �����մϴ�." + "</size>", " . . . ", "<size=75%>" + "���濡 ���� �ڵ� �ĺ� �Ұ����� <color=aqua>�κ�</color>�� �ټ� Ȯ�ε�." + "</size>", "<size=75%> ������ ���� ������ ���� �ı��� �õ��մϴ�.</size>" });
        talkData.Add(100, new string[] { "<size=75%>�̰��� ����� ���� ���� ���� �и��� ���������� ���̴�.</size>", " . . . ", "<size=150%> �̷�����!!!!! </size>", " �״��� ������ ���� ������." });
        talkData.Add(200, new string[] { "<color=#d3de8b>NPC2</color>\n<size=75%>�ȳ�</size>", "<color=#d3de8b>NPC2</color>\n���� �ִ°�?", "<color=#d3de8b>NPC2</color>\n�� �ִٳ�!" });
        talkData.Add(1000, new string[] { "�̰��� ���� ������� ������ ���� ������ �����ȴ�.", "���� ���� ����ü�� ���������� Ȯ���� �� �ִ�.", "���ο� �κ��� ��۵���� ������ �νĵȴ�." });
        talkData.Add(1001, adad);
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length) return null;
        else return talkData[id][talkIndex];
    }
}
