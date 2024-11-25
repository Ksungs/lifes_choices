using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShaderManager : MonoBehaviour
{
    public Image image; // UI Image 오브젝트를 연결할 변수
    public Text shaderTxt; // UI Text 오브젝트를 연결할 변수
    public GameObject ShaderTxtO;
    public GameManager gameManager; // GameManager 스크립트를 연결할 변수
    public float fadeDuration = 2f; // 페이드 아웃에 걸리는 시간
    public float waitDuration; // 대기 시간

    private void OnEnable()
    {
        // 이미지가 활성화될 때 FadeOut 코루틴 시작
        waitDuration = 1f;
        StartCoroutine(FadeOut());
        
    }

    private IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        Color color = image.color;
        Debug.Log("FadeOut 시작"); // 코루틴 시작 로그
        color.a = 1f;
        image.color = color;
        // 텍스트 업데이트
        if (gameManager != null)
        {
            if (!(gameManager.progressIndex==0))
            {
                ShaderTxtO.SetActive(true);
                UpdateShaderText();
            }
        }
        
        yield return new WaitForSeconds(waitDuration);
        ShaderTxtO.SetActive(false);
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            image.color = color;
            yield return null; // 다음 프레임까지 대기
        }

        // 최종적으로 완전히 투명하게 설정
        color.a = 0f;
        image.color = color;
        Debug.Log("FadeOut 완료"); // 코루틴 완료 로그
        gameObject.SetActive(false);
    }

    private void UpdateShaderText()
    {
        if (gameManager != null)
        {
            Debug.Log("Shade progressIndex: " + gameManager.progressIndex);
            switch (gameManager.progressIndex)
            {
                case 1:
                    shaderTxt.text = "어린 시절";
                    Debug.Log("progress: " + gameManager.progressIndex);
                    break;
                case 2:
                    shaderTxt.text = "청소년기";
                    Debug.Log("progress: " + gameManager.progressIndex);
                    break;
                case 3:
                    shaderTxt.text = "청년기";
                    Debug.Log("progress: " + gameManager.progressIndex);
                    break;
                case 4:
                    shaderTxt.text = "중년기";
                    Debug.Log("progress: " + gameManager.progressIndex);
                    break;
                case 5:
                    shaderTxt.text = "노년기";
                    Debug.Log("progress: " + gameManager.progressIndex);
                    break;
                default:
                    ShaderTxtO.SetActive(false);
                    break;
            }
        }
        else
        {
            ShaderTxtO.SetActive(false);
        }
    }
}
