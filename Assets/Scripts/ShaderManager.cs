using UnityEngine;
using UnityEngine.UI; // UI 관련 네임스페이스 추가
using System.Collections;

public class ShaderManager : MonoBehaviour
{
    private Image objectImage;
    private Color objectColor;

    void Awake()
    {
        // Image 컴포넌트를 가져옵니다.
        objectImage = GetComponent<Image>();
        if (objectImage == null)
        {
            Debug.LogWarning("Image 컴포넌트가 이 게임 오브젝트에 없습니다.");
            return; // 스크립트를 중단
        }

        objectColor = objectImage.color;
        objectColor.a = 1; // 초기 투명도 설정 (불투명)
        objectImage.color = objectColor;
    }

    void OnEnable()
    {
        StartCoroutine(FadeOutCoroutine(1.0f)); // 1초 동안 서서히 투명하게
    }

    private IEnumerator FadeOutCoroutine(float duration)
    {
        float startAlpha = objectColor.a;
        float endAlpha = 0.0f; // 최종 투명도 (투명)
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float currentAlpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration);
            objectColor.a = currentAlpha;
            objectImage.color = objectColor;
            yield return null;
        }

        objectColor.a = endAlpha;
        objectImage.color = objectColor; // 최종값 설정
        gameObject.SetActive(false);
    }
}
