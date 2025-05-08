using UnityEngine;
using UnityEngine.UI;

public class text : MonoBehaviour
{
    public GameObject star1;
    public Text TotalText; 
    public bool theend = true;
    public float score;
    

    void Start()
    {
        star1 = GameObject.Find("star");
        
    }

    void Update()
    {
        star starComponent = star1.GetComponent<star>();
        theend = starComponent.isMoving;
        score = starComponent.total;
        if (theend = false)
        {
            TotalText.text = "최종 점수: " + score.ToString();
        }
    }

}
