using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShaderMini : MonoBehaviour
{
    public Image image; // UI Image 오브젝트를 연결할 변수
    private float fadeDuration = 1f; // 페이드 아웃에 걸리는 시간
    private float waitDuration; // 대기 시간

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

        yield return new WaitForSeconds(waitDuration);
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
}
