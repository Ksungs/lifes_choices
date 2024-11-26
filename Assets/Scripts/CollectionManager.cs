using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;

public class CollectionManager : MonoBehaviour
{
    private string collectionFilePath;
    private HashSet<int> collectedItems; // 중복 방지용 HashSet
    private CanvasGroup canvasGroup; // 투명도 제어용 CanvasGroup
    public Image targetImageUI; // 변경할 Image UI 컴포넌트
    public GameObject Zoom;

    void Start()
    {
        // JSON 파일 경로 설정
        collectionFilePath = Path.Combine(Application.persistentDataPath, "collection.json");

        // JSON 데이터 로드
        LoadCollectedItems();

        // Button 및 CanvasGroup 설정
        Button targetButton = GetComponent<Button>();
        if (targetButton == null)
        {
            Debug.LogError("CollectionManager는 Button 컴포넌트가 필요한 GameObject에 붙어야 합니다.");
            return;
        }

        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            // CanvasGroup이 없으면 추가
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }

        // 현재 GameObject 이름을 숫자로 변환 후 -1 적용
        if (int.TryParse(gameObject.name, out int objectID))
        {
            int adjustedID = objectID - 1; // ID - 1로 조정
            // 조정된 ID가 수집된 목록에 없는 경우 투명도 및 상호작용 상태 설정
            if (!collectedItems.Contains(adjustedID))
            {
                canvasGroup.alpha = 0.5f; // 반투명 처리
                canvasGroup.interactable = false; // 상호작용 비활성화
            }
            else
            {
                canvasGroup.alpha = 1f; // 완전한 불투명
                canvasGroup.interactable = true; // 상호작용 활성화
            }
        }
        else
        {
            Debug.LogWarning($"GameObject 이름 '{gameObject.name}'은 숫자로 변환할 수 없습니다.");
        }
    }

    // JSON 파일에서 수집된 항목 로드
    private void LoadCollectedItems()
    {
        if (File.Exists(collectionFilePath))
        {
            string jsonData = File.ReadAllText(collectionFilePath);
            CollectionData data = JsonConvert.DeserializeObject<CollectionData>(jsonData);
            collectedItems = new HashSet<int>(data.collectedItems);
        }
        else
        {
            Debug.LogWarning("Collection.json 파일이 존재하지 않습니다.");
            collectedItems = new HashSet<int>();
        }
    }

    // 특정 Image UI 오브젝트의 이미지 소스를 변경
    public void UpdateImageUI()
    {
        Zoom.SetActive(true);
        if (targetImageUI == null)
        {
            Debug.LogError("Image UI 오브젝트가 지정되지 않았습니다.");
            return;
        }

        // Resources 폴더 기반 이미지 경로 설정
        string imagePath = gameObject.name; // 파일명만 사용, 확장자는 제거
        Debug.Log($"이미지 로드 시도: {imagePath}");

        // Resources에서 이미지 로드 및 적용
        Sprite newSprite = Resources.Load<Sprite>(imagePath);
        if (newSprite != null)
        {
            targetImageUI.sprite = newSprite;
        }
        else
        {
            Debug.LogError("이미지를 찾을 수 없거나 로드할 수 없습니다: " + imagePath);
        }
    }

    [System.Serializable]
    private class CollectionData
    {
        public List<int> collectedItems;
    }
}
