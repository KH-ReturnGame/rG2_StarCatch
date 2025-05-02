using UnityEngine;
using UnityEngine.UI;

public class text_stript : MonoBehaviour
{
    public GameObject star1;
    public Text TotalText; // Inspector에서 할당하거나, Start()에서 GetComponent로 찾음
    public bool theend = true;
    public float score;
    private RectTransform textRectTransform;
    private CanvasScaler canvasScaler;
    private Vector2 originalAnchorMin;
    private Vector2 originalAnchorMax;
    private Vector2 originalPivot;
    private Vector2 originalAnchoredPosition;
    private int originalFontSize;

    void Start()
    {
        star1 = GameObject.Find("star");
        if (star1 == null)
        {
            Debug.LogError("Could not find GameObject named 'star'. Make sure it exists in your scene.");
            enabled = false;
            return;
        }

        // 스크립트가 UI Text GameObject에 붙어있다면 GetComponent<Text>() 사용
        TotalText = GetComponent<Text>();
        if (TotalText == null)
        {
            Debug.LogError("This script needs to be attached to a GameObject with a UI Text component.");
            enabled = false;
            return;
        }

        // Text 컴포넌트가 속한 RectTransform 가져오기
        textRectTransform = TotalText.GetComponent<RectTransform>();
        if (textRectTransform == null)
        {
            Debug.LogError("UI Text GameObject must have a RectTransform component.");
            enabled = false;
            return;
        }

        // CanvasScaler 컴포넌트 찾기 (화면 중앙 계산에 필요)
        Canvas canvas = GetComponentInParent<Canvas>();
        if (canvas != null)
        {
            canvasScaler = canvas.GetComponent<CanvasScaler>();
        }
        else
        {
            Debug.LogError("UI Text GameObject must be a child of a Canvas.");
            enabled = false;
            return;
        }

        // 초기 위치 및 앵커 정보 저장
        originalAnchorMin = textRectTransform.anchorMin;
        originalAnchorMax = textRectTransform.anchorMax;
        originalPivot = textRectTransform.pivot;
        originalAnchoredPosition = textRectTransform.anchoredPosition;
        originalFontSize = TotalText.fontSize;
    }

    void Update()
    {
        if (star1 != null)
        {
            star starComponent = star1.GetComponent<star>();
            if (starComponent != null)
            {
                theend = starComponent.isMoving;
                score = starComponent.total;

                if (theend == true)
                {
                    TotalText.text = "현재 점수:" + score.ToString();

                }
                else
                {
                    TotalText.text = "최종 점수: " + score.ToString();
                    TotalText.fontSize = 60; // 글자 크기를 60으로 키움
                    //여기에 입력
                    textRectTransform.anchoredPosition = new Vector3(0, 0, 3f);
                    Debug.Log("dasdsad");
                }
            }
            else
            {
                Debug.LogError("The 'star' GameObject does not have a 'Star' script attached.");
                enabled = false;
            }
        }
    }
}