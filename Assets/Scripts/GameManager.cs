using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool IsGameOver { get; private set; }

    private int score;

    public TextMeshProUGUI scoreText;
    public GameObject gameOverUi;

    public void Awake()
    {
        gameOverUi.SetActive(false);
        score = 0;
    }

    private void Update()
    {
        if (IsGameOver && Input.GetMouseButtonDown(0))
        {
            IsGameOver = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void AddScore(int add)
    {
        if (!IsGameOver)
        {
            score += add;
            scoreText.text = $"Score: {score}";
        }
    }

    public void OnPlayerDead()
    {
        IsGameOver = true;
        gameOverUi.SetActive(true);
    }
}
