using UnityEngine;
using UnityEngine.EventSystems; // EventSystem 관련 네임스페이스

public class HowClick : MonoBehaviour, IPointerClickHandler // IPointerClickHandler 인터페이스 구현
{
    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject clickedObject = eventData.pointerCurrentRaycast.gameObject;

        // 클릭된 오브젝트가 자신인 경우
        if (clickedObject == gameObject)
        {
            Debug.Log("Clicked on How2Play!");
            gameObject.SetActive(false); // 오브젝트 비활성화
        }
    }
}