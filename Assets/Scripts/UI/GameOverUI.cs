using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] CountDownTimer countDownTimer;
    private AudioSource audio;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;

        Spikes.OnGameOver += Spikes_OnGameOver;
        Player.Instance.OnPlayerDead += Player_OnPlayerDead;
        countDownTimer.OnTimeFinished += CountDownTimer_OnTimeFinished;
    }

    private void CountDownTimer_OnTimeFinished(object sender, System.EventArgs e)
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    private void Player_OnPlayerDead(object sender, System.EventArgs e)
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    private void Spikes_OnGameOver(object sender, System.EventArgs e)
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    private void OnDisable()
    {
        Spikes.OnGameOver -= Spikes_OnGameOver;
        Player.Instance.OnPlayerDead -= Player_OnPlayerDead;
        countDownTimer.OnTimeFinished -= CountDownTimer_OnTimeFinished;
    }
}
