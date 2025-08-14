using Unity.Mathematics;
using UnityEngine;

public class cameraControllerFlappyBird : MonoBehaviour
{
    public player player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (player == null)
        {
            player = GameObject.Find("player").GetComponent<player>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.instance.gameOver)
        {
            transform.position = player.transform.position + new Vector3(4, 0);
        }
        
    }
}
