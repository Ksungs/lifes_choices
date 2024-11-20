using UnityEngine;
using UnityEngine.UI; // UI 관련 네임스페이스
using System.IO; // 파일 입출력

public class RBtnManager : MonoBehaviour
{
    public string filePath; // 파일 경로

    void Start()
    {
        // 파일 경로 설정
        filePath = Path.Combine(Application.persistentDataPath, "output.txt");
    }

    public void AppendR()
    {
        // "1"을 파일에 추가
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.Write("1");
        }
        
        Debug.Log("1 has been appended to " + filePath);
    }
}
