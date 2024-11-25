using UnityEngine;
using System.IO; // 파일 입출력

public class RBtnManager : MonoBehaviour
{
    public string filePath; // 파일 경로
    private GameManager gameManager; // GameManager 참조
    public GameObject Shader;

    void Start()
    {
        // 파일 경로 설정
        filePath = Path.Combine(Application.persistentDataPath, "output.txt");
        gameManager = FindObjectOfType<GameManager>(); // GameManager 인스턴스 찾기
    }

    public void AppendR()
    {
        // "0"을 파일에 추가
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.Write("1");
        }

        // GameManager의 progressIndex 증가
        gameManager.progressIndex++; // progressIndex 증가
        Debug.Log("Button ProgressIndex: " + gameManager.progressIndex);
        Shader.SetActive(true);
    }
}
