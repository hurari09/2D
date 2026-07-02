using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    // 현재 점수 UI 변수
    public TextMeshProUGUI currentUI;
    // 현재 점수 변수
    public int currentScore = 0;
    // 최고 점수 UI 변수
    public TextMeshProUGUI bestUI;
    // 최고 점수 변수
    public int bestScore = 0;

    public TextMeshProUGUI feverUI;
    public Image feverImg;

    public int feverCount = 0;
    public float maxFeverCount = 10f;
    public bool isFever = false;
    public float feverDuration = 5f;
    float RemainTime;
    bool feverFlag = false;

    public PlayerMove playerMove;
    public PlayerFire playerFire;

    public TextMeshProUGUI hpUI;

    public TextMeshProUGUI gameOverUI;
    public Button restartBtn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 최고 점수 불러와서 bestScore 변수에 저장
        bestScore = PlayerPrefs.GetInt("Best Score", 0);
        // 최고 점수를 화면에 표시
        bestUI.text = $"Best Score: {bestScore}";
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFever && feverCount >= maxFeverCount)
        {
            feverImg.fillAmount = feverCount / maxFeverCount;
            isFever = true;
            feverCount = 0;
            RemainTime = feverDuration;
        }
        if (isFever)
        {
            if (!feverFlag)
            {
                playerMove.feverSpeed *= 2f;
                playerFire.fireRate /= 2f;
            }
            feverFlag = true;

            RemainTime -= Time.deltaTime;
            feverImg.fillAmount = RemainTime / feverDuration;

            if (RemainTime <= 0)
            {
                isFever = false;
                feverFlag = false;

                playerMove.feverSpeed = 1f;
                playerFire.fireRate = 0.5f;
            }
        }
        else
        {
            feverImg.fillAmount = feverCount / maxFeverCount;
        }
    }

    public void ClickBtn()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("ShootingGame");
    }
}
