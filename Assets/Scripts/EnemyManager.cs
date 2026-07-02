using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    float currentTime = 0; // 현재 시간
    public float createTime = 2.0f; // 일정 시간
    public GameObject enemy; // 적 프리팹
    float minTime = 1; // 최소 시간
    float maxTime = 5; // 최대 시간

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 최초의 적 생성시간 설정
        createTime = Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        // 현재 시간 갱신
        currentTime += Time.deltaTime;
        // 일정 시간마다 적 생성
        if(currentTime > createTime)
        {
            // 적 생성 후 내 위치로 이동
            Instantiate(enemy, transform.position, Quaternion.identity);
            // 현재 시간 초기화
            currentTime = 0;
            // 다음 적 생성시간 랜덤하게 설정
            createTime = Random.Range(minTime, maxTime);
        }
    }
}
