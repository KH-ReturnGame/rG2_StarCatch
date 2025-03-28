using UnityEngine;
using UnityEngine.UI;

public class RandomGradientChanger : MonoBehaviour
{
    private Material gradientMaterial;
    void Start()
    {
        
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1) == true)
        {
            float randomFloat = Random.Range(-6.0f, 9.0f);
            
            gameObject.transform.position = new Vector3(randomFloat, -4, -1);
        }
    }
}
