using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] Star star;

    private int score;
    private int bestScore;
    [SerializeField] Text playerBestScore;
    [SerializeField] Text Score;

    private const string BEST_SCORE = "Best_Score";

    void Start()
    {
        bestScore = PlayerPrefs.GetInt(BEST_SCORE, 0);
        playerBestScore.text = bestScore.ToString();
        star.OnScoreChanged += Star_OnScoreChanged;
    }

    private void Star_OnScoreChanged(object sender, System.EventArgs e)
    {
        score++;
        Score.text = score.ToString();
        if (bestScore < score)
        {
            PlayerPrefs.SetInt(BEST_SCORE, score);
        }
    }
}
