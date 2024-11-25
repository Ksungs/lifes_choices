using System.Collections; // 코루틴 사용을 위한 네임스페이스
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    private int currentIndex = 0; // 현재 스토리 인덱스
    public int progressIndex = 0; // 진행 상태 인덱스
    public Text InitText; // 스토리 텍스트를 표시할 UI Text
    public Text ChoiceText; // 스토리 텍스트를 표시할 UI Text
    public Image StoryImg; // 스토리 이미지를 표시할 UI Image
    public GameObject InitStoryObject; // 초기 스토리 오브젝트
    public GameObject LeftBtn;
    public GameObject Shader;

    public Text LeftBtnText;
    public GameObject RightBtn;
    public Text RightBtnText;
    public Sprite FirstImg; // 첫 번째 이미지
    public Sprite SecondImg; // 두 번째 이미지
    public Sprite ThirdImg; // 세 번째 이미지
    public Sprite FourthImg; // 네 번째 이미지
    public Sprite FifthImg; // 다섯 번째 이미지

    // 초기 스토리 내용 배열
    private string[] InitStory = {
        "플레이어는 한 사람의 인생을 처음부터 끝까지 경험합니다.",
        "유년기부터 노년기까지, 인생의 중요한 순간마다 5개의 지문이 등장합니다.",
        "플레이어는 각 선택마다 두 가지 보기 중 하나를 선택합니다.",
        "이 선택들이 쌓여 마지막에 플레이어의 인생을 요약하는 최종 스토리가 결정됩니다.",
        "각 선택은 단순해 보여도 예상치 못한 결과를 초래할 수 있습니다.",
        "그럼 행운을 빕니다."
    };

    // 선택 스토리 배열 (예시)
    private string[] ChoiceStory = {
        "새 학기에 첫 친구를 사귈 기회가 생겼습니다. 어떤 친구와 어울릴까요?",
        "무엇에 집중하며 고등학교 시절을 보낼까요?",
        "첫사랑과의 연애를 시작하게 되었습니다. 어떤 자세로 연애를 이어갈까요?",
        "안정적인 직장에 만족하던 중 창업의 기회가 찾아옵니다. 어떻게 할까요?",
        "은퇴 후 남은 인생을 어떻게 보낼까요?"
    };

    // 왼쪽 선택지 배열
    private string[] LeftOption = {
        "활발하고 인기가 많은 친구와 어울린다.",
        "공부에 매진해 원하는 대학에 진학한다.",
        "자신의 꿈과 목표를 최우선으로 두며 독립적으로 연애한다.",
        "안정적인 직장에 남는다.",
        "가족과 시간을 보내며 조용한 삶을 산다."
    };

    // 오른쪽 선택지 배열
    private string[] RightOption = {
        "조용하고 책을 좋아하는 친구와 어울린다.",
        "예체능 활동에 몰두하며 다양한 경험을 쌓는다.",
        "연인과 시간을 우선시하며 서로의 관계에 집중한다.",
        "모험을 선택하고 창업에 도전한다.",
        "새로운 취미를 찾고 세계 여행을 떠난다."
    };

    // Start는 스크립트가 시작될 때 호출됩니다.
    void Start()
    {
        InitText.text = InitStory[currentIndex]; // 초기 스토리 텍스트 설정
        StoryImg.gameObject.SetActive(false); // 시작 시 이미지 비활성화
    }

    // Update는 매 프레임마다 호출됩니다.
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 클릭 시
        {
            if (!Shader.activeSelf){
                if (progressIndex == 0)
                {
                    InitFun();
                }
                else
                {
                    StartCoroutine(WaitAndChange()); // 0.5초 대기 후 텍스트 및 이미지 변경
                }
            }
        }
    }

    // 초기 스토리 진행 메서드
    void InitFun()
    {
        if (currentIndex < InitStory.Length - 1)
        {
            Shader.SetActive(true);
            currentIndex++;
            InitText.text = InitStory[currentIndex]; // 다음 스토리 텍스트로 변경
        }
        else
        {       
            progressIndex++;
            Shader.SetActive(true);
            StoryImg.gameObject.SetActive(true); // 이미지 활성화
            InitStoryObject.SetActive(false); // 초기 스토리 오브젝트 비활성화
            LeftBtn.SetActive(true);
            RightBtn.SetActive(true);
            ChangeImgFun();
            ChangeTxtFun();
        }
    }

    // 이미지 변경 메서드
    void ChangeImgFun()
    {
        switch(progressIndex)
        {
            case 1:
                StoryImg.sprite = FirstImg; // 첫 번째 이미지로 변경
                break;
            case 2:
                StoryImg.sprite = SecondImg; // 두 번째 이미지로 변경
                break;
            case 3:
                StoryImg.sprite = ThirdImg; // 두 번째 이미지로 변경
                break;
            case 4:
                StoryImg.sprite = FourthImg; // 두 번째 이미지로 변경
                break;
            case 5:
                StoryImg.sprite = FifthImg; // 두 번째 이미지로 변경
                break;
            // 추가적인 이미지 변경 로직을 여기에 추가 가능
        }
    }

    void ChangeTxtFun()
    {
        if (progressIndex < InitStory.Length)
        {
            LeftBtnText.text = LeftOption[progressIndex - 1];
            RightBtnText.text = RightOption[progressIndex - 1];
            ChoiceText.text = ChoiceStory[progressIndex - 1];
        }
        else
        {
            SceneManager.LoadScene("EndScene");

        }
    }

    // 0.1초 대기 후 텍스트 및 이미지 변경
    private IEnumerator WaitAndChange()
    {
        yield return new WaitForSeconds(0.5f); // 0.5초 대기
        ChangeImgFun(); // 이미지 변경
        ChangeTxtFun(); // 텍스트 변경
    }
}
