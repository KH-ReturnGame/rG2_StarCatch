using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class star : MonoBehaviour
{
    public float speed = 5f;
    public bool isMoving = false;
    private float Dist;
    public bool start = true;
    public Transform square;
    public int total = 0; // float에서 int로 변경
    public bool isChecking = true;
    public bool isend = false;
    public int count = 0;
    public GameObject imageObject;
    public GameObject TotalText;

    void Start()
    {
        isMoving = true;
        StartCoroutine(SmoothMoveAndReset());
    }

    void Update()
    {
        if (isChecking == true)
        {
            if(Input.GetKeyDown(KeyCode.Alpha2))
            {
                isChecking = false;
                Dist = Vector2.Distance(this.transform.position, square.transform.position);
                Debug.Log(30 - Dist);
                total = total + Mathf.RoundToInt(30 - Dist); // 계산 결과를 정수로 반올림하여 total에 저장
                Debug.Log("총합");
                Debug.Log(total);
            }
        }
    }
    IEnumerator Checking()
    {
        isChecking = true;
        yield return new WaitForSeconds(0.02f);
    }
    IEnumerator SmoothMoveAndReset()
    {
        int repeatCount = 0;
        while (repeatCount < 10)
        {
            isChecking = true;
            count++;

            Debug.Log("isChecking이 true");
            start = true;

            yield return StartCoroutine(MoveObjectSmoothly(1f));

            Debug.Log("isChecking이 false");
            speed += 3f;
            repeatCount++;

            gameObject.transform.position = new Vector3(-10, -4, -2);
            yield return new WaitForSeconds(1f);
            isChecking = false;

            start = false;


        }
        isMoving = false;
        Debug.Log("isMoving이 false");


    }

    IEnumerator MoveObjectSmoothly(float duration)
    {
        float startTime = Time.time;
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = transform.position + Vector3.right * speed * duration;
        while (Time.time < startTime + duration)
        {
            float t = (Time.time - startTime) / duration;
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            yield return null;
            float xPosition = transform.position.x;

            if(xPosition > 10f)
            {
                //MoveObjectSmoothly 코루틴 멈추기
                StopCoroutine(MoveObjectSmoothly(1f));
            }
        }
        transform.position = targetPosition;

    }


}