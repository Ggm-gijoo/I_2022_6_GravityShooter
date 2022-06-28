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
        talkData.Add(0, new string[] { "���� 5��2õ����", " �� �ð� �¾�� 17:09,\n���ݺ��� <size=125%><color=#00ffffff>������ ����</color></size>�� �����մϴ�.", " <size=150%>. . . </size>", " ���濡 ���� �ڵ� �ĺ� �Ұ����� <color=red>�κ�</color>�� �ټ� Ȯ�ε�.", " ������ ���� ������ ���� �ı��� �õ��մϴ�." });
        talkData.Add(100, new string[] { " �����ּż� �����մϴ�!", " <size=150%>. . . </size>", " ��... ���� ���� �ɱ��?", "����, �� �۽� ��ġ�� �̿��ؼ�... �����մϴ�!"});
        talkData.Add(101, new string[] { " ��! ���� �����̱���!", " ���� ��Ƴ��� �� �ִٴ�, �������̳׿�!", "�׷� �˷��ֽ� ��ġ�� �����Կ�!" });
        talkData.Add(102, new string[] { " <size=150%>����! ���� ��, �� ������!</size>", " <size=150%>. . . </size>", " ��... ���� �����̾�����... �������ּż� �����մϴ�!", "�� �۽� ��ġ�� Ű�� �̵��ϴ� ����? �׷� �����ڽ��ϴ�!" });
        talkData.Add(103, new string[] { " ��.. �ٸ��� �λ��� ���� �� ���ƿ�.", "��, �����Ͻ� ������ ���� ġ�� ���� �� �ִٱ���?", " ���⼭ ���� ������ �����ٴ�, �ϴ��� ���� ���Գ׿�.", " �� �۽� ��ġ�� Ű�� �ڵ����� �̵��Ѵٴ� �ű���. �����մϴ�." });
        talkData.Add(104, new string[] { " �ױ� �Ⱦ�.. �ױ� �ȴٰ�.... "," <size=125%>��?!</size> ... ��.. ���� �����̼̱���. �κ��� �� �˾Ҿ��.", " ���п� ������ �ƾ��, �����մϴ�.", " �� ���� ���ֿ� Ȧ�� �ִٴ� ������, ��� ������ ���ƹ��� �� ���ƿ�..", " �� �۽� ��ġ�� �Ѱ�... �۵� �� �� ����? �׷� ��<size=90%>��</size><size=80%>��..!</size>"});
        talkData.Add(105, new string[] { " ��... ���ֿ��� ��Ƴ��� 197���� ����...", " '������ ��⸦ �ٶ�� �� ���ְ� ������ �����ش�'? �̰� ��...", " ��! �������� �ű� ��̾��?", " �ƴ� �׺���, ��������? Ȥ�� å�� �����ִ� ��� �Ȱǰ�?", " ��! ���� �����̱���!", " ��! ����ġ�� ������ �Ǵ°���?" });
        talkData.Add(106, new string[] { " Thank You LifeGuard!", " �׷��� Our Princess�� Other Castle�� �־��!", " ������ �׷� Minute Thing? �߿�ġ �ʾƿ�.", " �� Reason? ���� save �����ϱ��!"});
        talkData.Add(107, new string[] { " �ƹ� ���� ����. �׳� ��ü�� �� �ϴ�.", " <size=150%>. . . </size>", " ��! ���� �����̼̱���! �κ����� ��ų��� ���� ô �ϰ� �־����!", " ��? �ƹ� ���� ���ٴ�? �̷��ĵ� �������� ��Ƴ��Ҵ°ɿ�!", "�׷� �̸� �����Կ�!" });
        talkData.Add(1000, new string[] { "�� ��Ҵ� ���� ������� ������ ���� ������ �����ȴ�.", "�� ����, �ش� ��ġ�� ���� ����ü�� ���������� Ȯ���� �� �ִ�.", "�����δ� ���輺�� �巯���� ������, ���ο��� <color=red>�κ�</color>�� ��۵���� �� ����.", "�����ڸ� �����ϱ� ���ؼ��� ���߸� �Ѵ�." });
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length) return null;
        else return talkData[id][talkIndex];
    }
}
