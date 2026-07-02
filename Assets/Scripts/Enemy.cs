using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5;
    // 이펙트 프리팹 변수
    public GameObject effect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // 방향 벡터 생성
        Vector3 dir = Vector3.down;
        // 이동
        transform.position += dir * speed * Time.deltaTime;
    }

    // 충돌 콜백 함수
    private void OnCollisionEnter(Collision collision)
    {
        // 적을 잡을 때마다 현재 점수 증가
        // 씬에서 ScoreManager 오브젝트 찾아서
        GameObject smObject = GameObject.Find("ScoreManager");
        // ScoreManager 스크립트 컴포넌트를 가져와서
        ScoreManager sm = smObject.GetComponent<ScoreManager>();

        PlayerMove player = collision.gameObject.GetComponent<PlayerMove>();
        if (player != null)
        {
            player.hp--;
            if (player.hp <= 0)
            {
                Destroy(collision.gameObject);

                Time.timeScale = 0;
                sm.gameOverUI.gameObject.SetActive(true);
                sm.restartBtn.gameObject.SetActive(true);
            }
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);

            sm.hpUI.text = $"HP: {player.hp}";
        }
        else
        {
            // ScoreManager 스크립트의 currentScore 변수에 10점 추가
            sm.currentScore += 10;
            // 화면에 현재 점수 표시
            sm.currentUI.text = $"Score: {sm.currentScore}";

            if (!sm.isFever)
            {
                sm.feverCount++;
            }

            // 최고 점수 갱신
            if (sm.currentScore > sm.bestScore)
            {
                sm.bestScore = sm.currentScore;
                sm.bestUI.text = $"Best Score: {sm.bestScore}";
                // PlayerPrefab에 최고 점수 저장
                PlayerPrefs.SetInt("Best Score", sm.bestScore);
            }

            Debug.Log("충돌 발생!");
            // 이펙트 생성(프리팹 생성 = Instantiate)
            Instantiate(effect, transform.position, Quaternion.identity);
            // 적 오브젝트(나 자신) 제거
            Destroy(gameObject);
            // 충돌한 상대방 오브젝트 제거
            Destroy(collision.gameObject);
        }
    }
}
