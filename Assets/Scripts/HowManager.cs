using UnityEngine;

public class HowManager : MonoBehaviour
{
    public GameObject howToPlayObject; // How2Play 오브젝트를 연결할 변수

    // 버튼 클릭 시 How2Play 오브젝트 활성화
    public void ShowHowToPlay()
    {
        if (howToPlayObject != null)
        {
            howToPlayObject.SetActive(true);
        }
    }

    // How2Play 오브젝트 클릭 시 비활성화
    public void HideHowToPlay()
    {
        if (howToPlayObject != null)
        {
            howToPlayObject.SetActive(false);
        }
    }
}
