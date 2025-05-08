using UnityEngine;
using System.Collections;

public class End : MonoBehaviour
{
    public GameObject starObject; // Inspector에서 "star" 오브젝트를 할당합니다.
    private star starScript; // 별 오브젝트의 star 스크립트

    void Start()
    {
        transform.position = new Vector3(0.5f, 0, 4); // 이 오브젝트의 초기 위치 설정
        Debug.Log("end 활성화");

        // starObject가 할당되었다면 star 컴포넌트를 찾습니다.
        if (starObject != null)
        {
            starScript = starObject.GetComponent<star>();
            if (starScript == null)
            {
                Debug.LogError("Star 오브젝트에 star 스크립트가 없습니다!");
            }
        }
        else
        {
            Debug.LogError("Inspector에 Star 오브젝트를 할당해주세요!");
        }
    }

    void Update()
    {
        // starScript가 null이 아니고, 별 스크립트의 count 값이 9보다 크면
        if (starScript != null && starScript.count > 10)
        {
            transform.position = new Vector3(1, 0, -4); // 이 오브젝트의 위치를 변경합니다.
        }
        IEnumerator sexy()
        {
            yield return new WaitForSeconds(1f);
        }
    }
}