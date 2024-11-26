using UnityEngine;

public class Click : MonoBehaviour
{
    public AudioSource audioSource; // Unity Editor에서 연결 가능

    void Start()
    {
        if (audioSource == null)
        {
            Debug.LogError("AudioSource가 연결되지 않았습니다. Unity Editor에서 오디오 소스를 할당하세요.");
        }
    }

    void Update()
    {
        // 마우스 왼쪽 버튼 클릭 감지
        if (Input.GetMouseButtonDown(0))
        {
            PlaySound();
        }
    }

    void PlaySound()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource가 설정되지 않아 사운드를 재생할 수 없습니다.");
        }
    }
}
