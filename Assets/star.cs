using UnityEngine;
using System.Collections;

public class star : MonoBehaviour
{
    public float speed = 5f;
    private bool isMoving = false;
    private float Dist;
    public bool start = true;
    public Transform square;

    void Start()
    {
        isMoving = true;
        StartCoroutine(SmoothMoveAndReset());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2) && square != null)
        {
            Dist = Vector2.Distance(this.transform.position, square.transform.position);
            Debug.Log(Dist);
        }
        else
        {
            
        }
    }

    IEnumerator SmoothMoveAndReset()
    {
        int repeatCount = 0;
        while (repeatCount < 10)
        {
            start = true;
            Debug.Log("Moving...");
            yield return StartCoroutine(MoveObjectSmoothly(1f));

            speed += 3f;
            repeatCount++;

            gameObject.transform.position = new Vector3(-10, -4, -2);
            yield return new WaitForSeconds(1f);
            start = false;
        }

        isMoving = false;
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
        }
        transform.position = targetPosition;
    }
}