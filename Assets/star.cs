using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class star : MonoBehaviour
{
    public GameObject square;
    public float speed = 5f;
    private bool isMoving = false;
    private float Dist;
    void Start()
    {
        isMoving = true;
        StartCoroutine(SmoothMoveAndReset());
    }
    void FixedUpade()
        {
            if (Input.GetKeyDown(KeyCode.Alpha3) && !isMoving)
            {
                
            }
        }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Dist = Vector2.Distance(this.transform.position, square.transform.position);//별과 네모
            Debug.Log(Dist);
        }
        

    }
    

    IEnumerator SmoothMoveAndReset()
    {
        int repeatCount = 0;
        while (repeatCount < 10)
        {
            Debug.Log("Moving...");
            yield return StartCoroutine(MoveObjectSmoothly(1f));

            speed += 3f;

            yield return new WaitForSeconds(0.2f);
            Debug.Log("Reset");
            repeatCount++;
            
            gameObject.transform.position = new Vector3(-10, -4, -2);
            yield return new WaitForSeconds(1f);

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