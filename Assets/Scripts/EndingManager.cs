using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CollectionData
{
    public List<int> collectedItems = new List<int>(); // 10진수 리스트로 변경
}

public class EndingManager : MonoBehaviour
{
    public Image imageUI; // 변경할 이미지 UI
    private string filePath;
    private string collectionFilePath;

    void Start()
    {
        filePath = Path.Combine(Application.persistentDataPath, "output.txt");
        collectionFilePath = Path.Combine(Application.persistentDataPath, "collection.json");
        ReadBinaryData();
    }

    void ReadBinaryData()
    {
        if (File.Exists(filePath))
        {
            string binaryValue = File.ReadAllText(filePath).Trim();
            if (IsBinaryValueValid(binaryValue))
            {
                ChangeImage(binaryValue);
                SaveToCollection(binaryValue); // 10진수로 저장
            }
            else
            {
                Debug.LogError("유효하지 않은 2진수 값입니다: " + binaryValue);
            }
        }
        else
        {
            Debug.LogError("파일이 존재하지 않습니다: " + filePath);
        }
    }

    bool IsBinaryValueValid(string binaryValue)
    {
        return binaryValue.Length == 5 && System.Text.RegularExpressions.Regex.IsMatch(binaryValue, "^[01]+$");
    }

    void ChangeImage(string binaryValue)
    {
        int index = Convert.ToInt32(binaryValue, 2);
        int fileIndex = index + 1;

        // Resources 폴더 경로에 맞는 이미지 로드
        string imagePath = $"{fileIndex}"; // 확장자는 생략
        Debug.Log("이미지 경로: " + imagePath);

        Sprite newSprite = Resources.Load<Sprite>(imagePath);
        if (newSprite != null)
        {
            imageUI.sprite = newSprite;
        }
        else
        {
            Debug.LogError("이미지를 찾을 수 없습니다: " + imagePath);
        }
    }

    void SaveToCollection(string binaryValue)
    {
        int decimalValue = Convert.ToInt32(binaryValue, 2); // 2진수를 10진수로 변환
        CollectionData collectionData;

        // 콜렉션 파일이 존재하면 읽기
        if (File.Exists(collectionFilePath))
        {
            string json = File.ReadAllText(collectionFilePath);
            collectionData = JsonUtility.FromJson<CollectionData>(json);

            // JSON 데이터를 읽어왔지만 null일 수 있음, 초기화
            if (collectionData == null)
            {
                collectionData = new CollectionData();
            }
        }
        else
        {
            // 파일이 없으면 새로 초기화
            collectionData = new CollectionData();
        }

        // 중복 체크 후 저장
        if (!collectionData.collectedItems.Contains(decimalValue))
        {
            collectionData.collectedItems.Add(decimalValue);
            string updatedJson = JsonUtility.ToJson(collectionData, true);
            File.WriteAllText(collectionFilePath, updatedJson);
            Debug.Log("콜렉션에 저장 완료: " + decimalValue);
        }
        else
        {
            Debug.Log("중복된 값이므로 저장하지 않습니다: " + decimalValue);
        }
    }
}
