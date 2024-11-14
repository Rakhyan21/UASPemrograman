using UnityEngine.UI;
using UnityEngine;


public class GameManager2 : MonoBehaviour
{
    public Player player;
    public Text scoreText;
    public GameObject PlayButton;
    public GameObject gameOver;
    public GameObject endPointPrefab;  // The endpoint object to spawn
    private int score;
    public GameObject PanelPlay;

    AudioManager audioManager;

    private void Awake()
    {
        PanelPlay.SetActive(false);
        Application.targetFrameRate = 144;
        //Pause();

        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        PlayButton.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();
        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void GameOver()
    {
        PanelPlay.SetActive(true);
        gameOver.SetActive(true);
        PlayButton.SetActive(true);
        Pause();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();

        // Check if score is 10 to spawn the endpoint
        //if (score == 2)
        {
            //Instantiate(endPointPrefab, new Vector3(1, 1, 0), Quaternion.identity);  // Adjust position as needed
        }
    }
}
