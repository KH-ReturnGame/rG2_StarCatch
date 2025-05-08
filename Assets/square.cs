using UnityEngine;
using System.Collections;

public class RandomGradientChanger : MonoBehaviour
{
    private Material gradientMaterial;
    private star starScript; // star.cs 스크립트 컴포넌트를 저장할 변수

    void Start()
    {
        gameObject.transform.position = new Vector3(-10, -4, -2);
        GameObject starObject = GameObject.Find("star");
        if (starObject != null)
        {
            starScript = starObject.GetComponent<star>();
            if (starScript == null)
            {
                Debug.LogError("star GameObject에 star 스크립트가 연결되어 있지 않습니다.");
            }
        }
        else
        {
            Debug.LogError("star GameObject를 찾을 수 없습니다.");
        }

        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            gradientMaterial = renderer.material;
        }
        else
        {
            Debug.LogError("Renderer 컴포넌트를 찾을 수 없습니다.");
        }
    }

    public void Update()
    {
        if (starScript != null && starScript.start)
        {
            float randomFloat = Random.Range(-6.0f, 9.0f);
            transform.position = new Vector3(randomFloat, -4, -1);
            StartCoroutine("se");
        }
        starScript.start = false;
        
    }
    IEnumerator se()
    {    
        yield return new WaitForSeconds(22f);
        starScript.start = true;
    }
}