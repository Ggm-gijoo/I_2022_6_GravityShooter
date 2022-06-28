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
        talkData.Add(0, new string[] { "서기 5억2천만년", " 현 시각 태양력 17:09,\n지금부터 <size=125%><color=#00ffffff>생존자 구출</color></size>을 시작합니다.", " <size=150%>. . . </size>", " 전방에 인증 코드 식별 불가능한 <color=red>로봇</color>이 다수 확인됨.", " 수월한 작전 진행을 위해 파괴를 시도합니다." });
        talkData.Add(100, new string[] { " 구해주셔서 감사합니다!", " <size=150%>. . . </size>", " 그... 어디로 가면 될까요?", "아하, 이 송신 장치를 이용해서... 감사합니다!"});
        talkData.Add(101, new string[] { " 앗! 지원 병력이군요!", " 드디어 살아나갈 수 있다니, 감동적이네요!", "그럼 알려주신 위치로 가볼게요!" });
        talkData.Add(102, new string[] { " <size=150%>으악! 저리 가, 이 깡통들아!</size>", " <size=150%>. . . </size>", " 아... 지원 병력이었구나... 구출해주셔서 감사합니다!", "이 송신 장치를 키면 이동하는 거죠? 그럼 가보겠습니다!" });
        talkData.Add(103, new string[] { " 윽.. 다리에 부상을 입은 것 같아요.", "앗, 말씀하신 곳으로 가면 치료 받을 수 있다구요?", " 여기서 지원 병력을 만나다니, 하늘이 저를 도왔네요.", " 이 송신 장치를 키면 자동으로 이동한다는 거군요. 감사합니다." });
        talkData.Add(104, new string[] { " 죽기 싫어.. 죽기 싫다고.... "," <size=125%>앗?!</size> ... 휴.. 지원 병력이셨군요. 로봇인 줄 알았어요.", " 덕분에 진정이 됐어요, 감사합니다.", " 이 넓은 우주에 홀로 있다는 생각에, 잠시 정신을 놓아버린 것 같아요..", " 이 송신 장치를 켜고... 작동 된 거 맞죠? 그럼 가<size=90%>볼</size><size=80%>ㄱ..!</size>"});
        talkData.Add(105, new string[] { " 음... 우주에서 살아남기 197쪽을 보면...", " '간절히 살기를 바라면 온 우주가 나서서 도와준다'? 이게 뭔...", " 헉! 언제부터 거기 계셨어요?", " 아니 그보다, 누구세요? 혹시 책에 나와있는 대로 된건가?", " 아! 지원 병력이군요!", " 네! 스위치만 누르면 되는거죠?" });
        talkData.Add(106, new string[] { " Thank You LifeGuard!", " 그러나 Our Princess는 Other Castle에 있어요!", " 하지만 그런 Minute Thing? 중요치 않아요.", " 그 Reason? 내가 save 됐으니까요!"});
        talkData.Add(107, new string[] { " 아무 말도 없다. 그냥 시체인 듯 하다.", " <size=150%>. . . </size>", " 앗! 지원 병력이셨군요! 로봇한테 들킬까봐 죽은 척 하고 있었어요!", " 네? 아무 쓸모 없다뇨? 이래봬도 아직까지 살아남았는걸요!", "그럼 이만 가볼게요!" });
        talkData.Add(1000, new string[] { "이 장소는 과거 거주장소 역할을 했을 것으로 추정된다.", "먼 옛날, 해당 위치에 지적 생명체가 존재했음을 확인할 수 있다.", "겉으로는 위험성이 드러나지 않으나, 내부에는 <color=red>로봇</color>이 드글드글한 것 같다.", "생존자를 구출하기 위해서는 들어가야만 한다." });
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length) return null;
        else return talkData[id][talkIndex];
    }
}
