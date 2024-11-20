using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class EndingManager : MonoBehaviour
{
    // Start is called before the first frame update
    private string filePath; // 파일 경로

    void Start()
    {
        // 파일 경로 설정
        filePath = Path.Combine(Application.persistentDataPath, "output.txt");
        ReadFile(); // 파일 읽기 메서드 호출
    }

    void ReadFile()
    {   
        // 파일 내용 읽기
        string fileContent = File.ReadAllText(filePath);
        Debug.Log("File Content:\n" + fileContent); // 파일 내용 로그에 표시
    }
}
