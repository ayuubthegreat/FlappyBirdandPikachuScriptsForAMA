using UnityEngine;

public class restartButton : MonoBehaviour
{
    public gameOver over;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        over = GetComponentInParent<gameOver>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnClick()
    {
        over.gameStarted = true;
    }
}
