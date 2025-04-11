using UnityEngine;
using UnityEngine.UI;

public class push : MonoBehaviour
{
    public GameObject Button; // 복제할 원본 오브젝트
    public Button[] buttons; // 알파벳 버튼 배열

    public void CloneObject()
    {
        if (Button != null)
        {
            GameObject clonedObject = Instantiate(Button);
            clonedObject.SetActive(true);
            Debug.Log(Button.name + " 오브젝트가 복제되어 활성화되었습니다.");
        }
    }

    public void ClickRandomButton()
    {
        if (buttons != null && buttons.Length > 0)
        {
            Button randomButton = buttons[Random.Range(0, buttons.Length)];
            randomButton.onClick.Invoke();
            Debug.Log(randomButton.name + " 버튼이 랜덤으로 클릭되었습니다.");
        }
        else
        {
            Debug.LogWarning("알파벳 버튼 배열이 비어 있습니다.");
        }
    }

    // star 스크립트에서 호출될 함수
    public void ExecuteActions()
    {
        CloneObject();
        ClickRandomButton();
    }
}