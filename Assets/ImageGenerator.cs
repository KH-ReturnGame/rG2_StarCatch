using UnityEngine;
using UnityEngine.UI;

public class ImageGenerator : MonoBehaviour
{
    public GameObject imagePrefab; // 생성할 이미지 프리팹
    public Transform parentTransform; // 이미지를 생성할 부모 트랜스폼

    public void GenerateImage()
    {
        // 이미지 프리팹이 존재하는지 확인
        if (imagePrefab != null)
        {
            // 이미지 프리팹을 복제하여 생성
            GameObject newImage = Instantiate(imagePrefab, parentTransform);

            // 생성된 이미지의 위치, 크기 등 설정 (선택 사항)
            // 예: newImage.transform.localPosition = Vector3.zero;

            Debug.Log("이미지가 생성되었습니다.");
        }
        else
        {
            Debug.LogWarning("이미지 프리팹이 할당되지 않았습니다.");
        }
    }
}