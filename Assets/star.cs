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
    public int repeatCount = 0;
    public int count = 0;
    public GameObject imageObject;
    public GameObject TotalText;
//클론
    public GameObject objectToClone;         // 복제할 게임 오브젝트 (Inspector 창에서 할당)
    public float destroyDelay = 0.3f;          // 클론이 생성된 후 사라질 때까지의 시간 (초)
    public float scaleDuration = 0.3f;      // 크기가 변하는 시간 (초)
    public float maxScaleMultiplier = 1.5f;  // 최대로 커질 크기의 배수


    void Start()
    {
        StartCoroutine("Checking");

    }

    void Update()
    {
        if (isChecking == true)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if(repeatCount < 10)
                {
                    SpawnClone();

                    isChecking = false;
                    Dist = Vector2.Distance(this.transform.position, square.transform.position);
                    Debug.Log(30 - Dist);
                    total = total + Mathf.RoundToInt(30 - Dist); // 계산 결과를 정수로 반올림하여 total에 저장
                    Debug.Log("총합");
                    Debug.Log(total);
                }

            }
        }
    }
    void SpawnClone()
    {
        if (objectToClone != null)
        {
            // 현재 오브젝트의 위치와 회전으로 클론 생성
            GameObject clone = Instantiate(objectToClone, transform.position, transform.rotation);

            // 생성된 클론의 초기 스케일 저장
            Vector3 originalScale = clone.transform.localScale;

            // 스케일 애니메이션 코루틴 시작
            StartCoroutine(AnimateScale(clone.transform, originalScale, scaleDuration, maxScaleMultiplier));

            // 소멸 코루틴 시작 (스케일 애니메이션 종료 후 실행되도록 수정)
            StartCoroutine(DestroyClone(clone, destroyDelay + scaleDuration)); // 스케일 시간만큼 딜레이 추가
        }
        else
        {
            Debug.LogError("복제할 오브젝트가 할당되지 않았습니다!");
        }
    }
    IEnumerator AnimateScale(Transform targetTransform, Vector3 originalScale, float duration, float multiplier)
    {
        float time = 0f;

        // 커지는 애니메이션
        while (time < duration / 2f)
        {
            if (targetTransform == null) yield break; // 오브젝트가 파괴되었으면 코루틴 종료
            float scaleFactor = Mathf.Lerp(1f, multiplier, time / (duration / 2f));
            targetTransform.localScale = originalScale * scaleFactor;
            time += Time.deltaTime;
            yield return null;
        }

        time = 0f;

        // 작아지는 애니메이션
        while (time < duration / 2f)
        {
            if (targetTransform == null) yield break; // 오브젝트가 파괴되었으면 코루틴 종료
            float scaleFactor = Mathf.Lerp(multiplier, 1f, time / (duration / 2f));
            targetTransform.localScale = originalScale * scaleFactor;
            time += Time.deltaTime;
            yield return null;
        }

        // 최종적으로 원래 크기로 설정
        if (targetTransform != null)
        {
            targetTransform.localScale = originalScale;
        }


    }
    IEnumerator DestroyClone(GameObject cloneObject, float delay = 0.1f)
    {
            // 'delay' 시간만큼 대기
            yield return new WaitForSeconds(0.5f); // 요청하신 딜레이 0.5초로 변경

            // 클론 오브젝트 소멸
            if (cloneObject != null) // 오브젝트가 아직 존재하는지 확인
            {
                Destroy(cloneObject);
                Debug.Log(cloneObject.name + "이(가) 소멸되었습니다.");
            }
    }
    IEnumerator Checking()
    {
        yield return new WaitForSeconds(1f);
        isMoving = true;
        StartCoroutine(SmoothMoveAndReset());

    }
    IEnumerator SmoothMoveAndReset()
    {
        while (repeatCount < 11)
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