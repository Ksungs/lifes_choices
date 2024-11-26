using UnityEngine;

public class HowClick : MonoBehaviour
{
    void Update()
    {
        // 마우스 왼쪽 버튼이 클릭되면 GameObject를 비활성화
        if (Input.GetMouseButtonDown(0))
        {
            gameObject.SetActive(false);
        }
    }
}
