using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoCollection : MonoBehaviour
{
    // 이 메서드는 UI 버튼 클릭 시 호출됩니다.
    public void Go2Collection()
    {
        SceneManager.LoadScene("CollectionScene");
    }
}
