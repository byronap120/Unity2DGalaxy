using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public Sprite[] lives;
    public Image livesImageDisplay;
    public TextMeshProUGUI scoreText;
    public Image mainMenuImage;
    public int score = 0;
    private bool _gameStarted = false;

    public void UpdateScore()
    {
        score += 10;
        scoreText.SetText("Score: " + score);
    }

    public void UpdateLives(int currentLives)
    {
        livesImageDisplay.sprite = lives[currentLives];

    }

    public void gameOVer()
    {
        updateUIViews(false);
    }

    public void startNewGame()
    {
        updateUIViews(true);

        // restart score
        score = 0;
        scoreText.SetText("Score: " + score);
    }

    private void updateUIViews(bool visible)
    {
        scoreText.gameObject.SetActive(visible);
        livesImageDisplay.gameObject.SetActive(visible);
        mainMenuImage.gameObject.SetActive(!visible);
    }
}
