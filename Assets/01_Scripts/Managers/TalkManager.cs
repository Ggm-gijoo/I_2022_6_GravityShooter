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

    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenData();
    }

    public void GenData()
    {
        talkData.Add(0, new string[] { "���� 5��2õ����"," �� �ð� �¾�� 17:09,\n���ݺ��� ������ ������ �����մϴ�.", " . . . ", " ���濡 ���� �ڵ� �ĺ� �Ұ����� �κ��� �ټ� Ȯ�ε�.", " ������ ���� ������ ���� �ı��� �õ��մϴ�." });
        talkData.Add(100, new string[] { " �����ּż� �����մϴ�!", " . . . ", " ��... ���� ���� �ɱ��?"});
        talkData.Add(101, new string[] { " ��! ���� �����̱���!", " ���� ��Ƴ��� �� �ִٴ�, �������̳׿�!", "�׷� �˷��ֽ� ��ġ�� �����Կ�!" });
        talkData.Add(102, new string[] { " ����! ���� ��, �� ������!", " . . .", " ��... ���� �����̾�����... �������ּż� �����մϴ�!" });
        talkData.Add(103, new string[] { " ��.. �ٸ��� �λ��� ���� �� ���ƿ�.", " ���⼭ ���� ������ �����ٴ�, �ϴ��� ���� ���Գ׿�.", " �׷� �������ֽ� ��ġ�� �����Կ�. �����մϴ�." });
        talkData.Add(1000, new string[] { "�� ��Ҵ� ���� ������� ������ ���� ������ �����ȴ�.", "�� ����, �ش� ��ġ�� ���� ����ü�� ���������� Ȯ���� �� �ִ�.", "�����δ� ���輺�� �巯���� ������, ���ο��� �κ��� ��۵���� �� ����." });
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length) return null;
        else return talkData[id][talkIndex];
    }
}
