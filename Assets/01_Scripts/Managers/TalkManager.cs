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
        talkData.Add(0, new string[] { "서기 5억2천만년"," 현 시각 태양력 17:09,\n지금부터 생존자 구출을 시작합니다.", " . . . ", " 전방에 인증 코드 식별 불가능한 로봇이 다수 확인됨.", " 수월한 작전 진행을 위해 파괴를 시도합니다." });
        talkData.Add(100, new string[] { " 구해주셔서 감사합니다!", " . . . ", " 그... 어디로 가면 될까요?"});
        talkData.Add(101, new string[] { " 앗! 지원 병력이군요!", " 드디어 살아나갈 수 있다니, 감동적이네요!", "그럼 알려주신 위치로 가볼게요!" });
        talkData.Add(102, new string[] { " 으악! 저리 가, 이 깡통들아!", " . . .", " 아... 지원 병력이었구나... 구출해주셔서 감사합니다!" });
        talkData.Add(103, new string[] { " 윽.. 다리에 부상을 입은 것 같아요.", " 여기서 지원 병력을 만나다니, 하늘이 저를 도왔네요.", " 그럼 말씀해주신 위치로 가볼게요. 감사합니다." });
        talkData.Add(1000, new string[] { "이 장소는 과거 거주장소 역할을 했을 것으로 추정된다.", "먼 옛날, 해당 위치에 지적 생명체가 존재했음을 확인할 수 있다.", "겉으로는 위험성이 드러나지 않으나, 내부에는 로봇이 드글드글한 것 같다." });
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length) return null;
        else return talkData[id][talkIndex];
    }
}
