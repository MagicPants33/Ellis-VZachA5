using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int score;
    private int lives;

    public TMP_Text scoreDisplay;
    public TMP_Text livesDisplay;
    public TMP_Text gameOverDisplay;

    public bool isMusicPlaying = true;
    public int songNumber = 0;

    public MusicMixer musicSwapper; 

    public void AddScore()
    {
        score++;
        UpdateScoreDisplay();
    }

    public void RemoveLife()
    {
        lives--;
        UpdateLivesDisplay();

        if (IsGameOver())
        {
            gameOverDisplay.enabled = true;
        }
    }

    public void ResetGame()
    {
        score = 0;
        lives = 3;
    }

    public bool IsGameOver()
    {
        return lives <= 0;
    }

    private void UpdateScoreDisplay()
    {
        scoreDisplay.text = $"Score: {score}";
        scoreDisplay.color = Color.yellow;  // Set the text color to yellow
    }

    private void UpdateLivesDisplay()
    {
        livesDisplay.text = $"Lives: {lives}";
        livesDisplay.color = Color.yellow;  // Set the text color to yellow
    }

    private void Start()
    {
        ResetGame();
        UpdateScoreDisplay();
        UpdateLivesDisplay();
        gameOverDisplay.enabled = false;
    }

    private void Update()
    {
        // Change music when the M key is pressed
        if (Input.GetKeyDown(KeyCode.M))
        {
            musicSwapper.NextTrack(); // Call the NextTrack method in MusicMixer
        }

        // Reset the game when the player presses R after game over
        if (IsGameOver() && Input.GetKeyDown(KeyCode.R))
        {
            Scene current = SceneManager.GetActiveScene();
            SceneManager.LoadScene(current.name);
        }
    }
}

