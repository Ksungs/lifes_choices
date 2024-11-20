using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameStart : MonoBehaviour
{
    public string filePath; // 파일 경로

    void Start()
    {
        // 파일 경로 설정 (Assets/Data/output.txt)
        filePath = Path.Combine(Application.persistentDataPath, "output.txt");
    }
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
        InitializeFile();
    }
        void InitializeFile()
    {
        // 파일을 초기화 (내용 삭제 및 새로 작성)
        using (StreamWriter writer = new StreamWriter(filePath, false)) // false는 파일을 덮어쓰기
        {
            writer.Write(""); // 빈 내용으로 초기화
        }

        Debug.Log("File has been initialized: " + filePath);
    }
}
