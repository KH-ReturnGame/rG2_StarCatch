using UnityEngine;
using TMPro;
using UnityEngine.UI; // CanvasScaler를 사용하기 위해 추가
using System.Collections; // 코루틴 사용을 위해 추가

public class text_stript : MonoBehaviour
{
    public GameObject star1;
    public TMP_Text TotalText;
    private float starcount = 0f; // star 스크립트의 count 값을 저장할 변수
    public float score;
    private RectTransform textRectTransform;
    private CanvasScaler canvasScaler;
    private Vector2 originalPosition; // 텍스트의 원래 위치 저장
    private bool textHidden = false; // 글자가 숨겨졌는지 여부 추적

    void Start()
    {
        star1 = GameObject.Find("star");
        if (star1 == null)
        {
            Debug.LogError("Could not find GameObject named 'star'. Make sure it exists in your scene.");
            enabled = false;
            return;
        }

        TotalText = GetComponent<TMP_Text>();
        if (TotalText == null)
        {
            Debug.LogError("This script needs to be attached to a GameObject with a UI TextMeshPro component.");
            enabled = false;
            return;
        }

        textRectTransform = TotalText.GetComponent<RectTransform>();
        if (textRectTransform == null)
        {
            Debug.LogError("UI TextMeshPro GameObject must have a RectTransform component.");
            enabled = false;
            return;
        }

        Canvas canvas = GetComponentInParent<Canvas>();
        if (canvas != null)
        {
            canvasScaler = canvas.GetComponent<CanvasScaler>();
            if (canvasScaler.uiScaleMode != CanvasScaler.ScaleMode.ScaleWithScreenSize)
            {
                Debug.LogWarning("Canvas Scale Mode is not set to 'Scale With Screen Size'. Centering might not be accurate on different resolutions.");
            }
        }
        else
        {
            Debug.LogError("UI TextMeshPro GameObject must be a child of a Canvas.");
            enabled = false;
            return;
        }

        if (TotalText != null)
        {
            TotalText.color = Color.white;
            originalPosition = textRectTransform.anchoredPosition; // 시작 시 원래 위치 저장
        }
    }

    void Update()
    {
        if (star1 != null)
        {
            star starComponent = star1.GetComponent<star>();
            if (starComponent != null)
            {
                starcount = starComponent.count;
                score = starComponent.total;

                if (starcount < 11)
                {
                    TotalText.text = "SCORE:" + score.ToString();
                    TotalText.color = Color.white; // count가 10보다 작을 때는 흰색 유지
                    textHidden = false; // 다시 보이도록 설정
                }
                else
                {
                    StartCoroutine ("HideTextAfterDelay");
                    TotalText.text = "TOTAL SCORE: " + score.ToString();
                    TotalText.color = Color.black; // count가 10보다 크면 검은색으로 변경
                    textRectTransform.anchorMin = new Vector2(0.5f, 0.5f);
                    textRectTransform.anchorMax = new Vector2(0.5f, 0.5f);
                    textRectTransform.pivot = new Vector2(0.5f, 0.5f);
                    textRectTransform.anchoredPosition = Vector2.zero;

                    if (!textHidden)
                    {
                        textHidden = true;
                    }
                }
            }
            else
            {
                Debug.LogError("The 'star' GameObject does not have a 'Star' script attached.");
                enabled = false;
            }
        }
    }

    IEnumerator HideTextAfterDelay()
    {
        yield return new WaitForSeconds(1f);
    }
}