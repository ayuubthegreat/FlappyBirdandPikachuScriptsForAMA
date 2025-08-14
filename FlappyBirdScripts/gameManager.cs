using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static gameManager instance;
    public player player;
    public pipe[] pipes;
    public Score[] scoreKeepers;
    public DistanceRegulator[] distanceRegulators;

    public bool gameOver = false;
    public Vector3 spawnPoint;
    public GameObject backgroundPrefab;
    public GameObject pipePrefab;
    public float pipeRandomOffset;
    public float distanceRegulatorRandomOffset;
    public int score = 0;
    public AudioSource audioSource;
    public AudioClip coinSound;
    public AudioClip jumpSound;
    public AudioClip hitSound;
    public AudioClip fallingSound;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        if (player == null) player = GameObject.FindFirstObjectByType<player>();
        spawnPoint = GameObject.Find("spawnPoint").transform.position;

        distanceRegulatorRandomOffset = Random.Range(5, 7);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pipes = FindObjectsByType<pipe>(FindObjectsSortMode.None);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            GameOverFunc();
        }
        pipes = FindObjectsByType<pipe>(FindObjectsSortMode.None);
        distanceRegulators = FindObjectsByType<DistanceRegulator>(FindObjectsSortMode.None);
        scoreKeepers = FindObjectsByType<Score>(FindObjectsSortMode.None);
    }
    public void GameOverFunc()
    {
        UIManager.instance.gameOverScreen.SetActive(true);
    }
    public void gameRestartedFunc()
    {
        UIManager.instance.gameOverScreen.SetActive(false);
        gameOver = false;
        player.isMovable = true;
        player.transform.position = spawnPoint;
        score = 0;
        player.rb.linearVelocity = Vector2.zero;
        ReassignArrayofTransforms();
        ReassignArrayofDistanceRegulators();
        EnableScores();




    }
    public void ReassignArrayofTransforms()
    {
        foreach (pipe pipeIterable in pipes)
        {
            pipeIterable.AssignTransforms();
        }
    }
    public void ReassignArrayofDistanceRegulators()
    {
        foreach (DistanceRegulator distanceRegulator in distanceRegulators)
        {
            distanceRegulator.AssignTransforms();
        }
    }
    public void EnableScores()
    {
        foreach (Score score in scoreKeepers)
        {
            score.b2d.enabled = true;
        }
    }
}
