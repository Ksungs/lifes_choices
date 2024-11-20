using UnityEngine;
using System.IO; // 파일 입출력

public class RBtnManager : MonoBehaviour
{
    public string filePath; // 파일 경로
    private GameManager gameManager; // GameManager 참조

    void Start()
    {
        // 파일 경로 설정
        filePath = Path.Combine(Application.persistentDataPath, "output.txt");
        gameManager = FindObjectOfType<GameManager>(); // GameManager 인스턴스 찾기
    }

    public void AppendR()
    {
        // "1"을 파일에 추가
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.Write("1");
        }

        // GameManager의 progressIndex 증가
        gameManager.progressIndex++; // progressIndex 증가
        Debug.Log("Progress Index updated to: " + gameManager.progressIndex);
        Debug.Log("1 has been appended to " + filePath);
    }
}
