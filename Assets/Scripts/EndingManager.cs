using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ImageChanger : MonoBehaviour
{
    public Image imageUI; // 변경할 이미지 UI
    private string filePath;

    void Start()
    {
        filePath = Path.Combine(Application.persistentDataPath, "output.txt");
        ReadBinaryData();
    }

    void ReadBinaryData()
    {
        if (File.Exists(filePath))
        {
            // 파일 내용을 읽습니다.
            string binaryValue = File.ReadAllText(filePath).Trim();

            // 2진수 값이 유효한지 확인
            if (IsBinaryValueValid(binaryValue))
            {
                ChangeImage(binaryValue);
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
        // 2진수 값이 5자리인지 확인
        return binaryValue.Length == 5 && System.Text.RegularExpressions.Regex.IsMatch(binaryValue, "^[01]+$");
    }

    void ChangeImage(string binaryValue)
    {
        // 2진수 값을 정수로 변환
        int index = Convert.ToInt32(binaryValue, 2);

        // index는 0부터 시작하므로 1을 더하여 파일 이름 생성
        int fileIndex = index + 1;

        // 이미지 경로 생성
        string imagePath = Path.Combine(Application.dataPath, "imgs/ending", fileIndex + ".png");

        // 경로 로그 출력
        Debug.Log("이미지 경로: " + imagePath);

        // 이미지 로드
        Sprite newSprite = LoadSprite(imagePath);
        if (newSprite != null)
        {
            imageUI.sprite = newSprite; // 이미지 변경
        }
        else
        {
            Debug.LogError("이미지를 찾을 수 없습니다: " + imagePath);
        }
    }

    Sprite LoadSprite(string path)
    {
        // Texture2D를 생성하고 파일에서 읽어오기
        Texture2D texture = new Texture2D(2, 2);
        if (File.Exists(path))
        {
            byte[] fileData = File.ReadAllBytes(path);
            texture.LoadImage(fileData); // PNG 또는 JPG 파일을 로드합니다.
            return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        }
        else
        {
            Debug.LogError("파일이 존재하지 않습니다: " + path);
            return null;
        }
    }
}
