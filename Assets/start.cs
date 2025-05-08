using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Button 컴포넌트 사용을 위해 추가
using System.Collections;
using System.Collections.Generic;
public class start : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("main");

    }
}