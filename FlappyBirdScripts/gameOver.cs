using UnityEngine;

public class gameOver : MonoBehaviour
{
    public Animator anim;
    public bool gameStarted = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("gameStarted", gameStarted);
    }
    public void StartGameover()
    {

        gameStarted = false;
        gameManager.instance.gameRestartedFunc();
        
    }
}
