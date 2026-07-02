using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // 총알을 생성할 공장
    public GameObject bulletFactory;
    // 총구 위치
    public GameObject firePosition;
    // 발사 간격
    public float fireRate = 0.5f;
    // 마지막 발사 시간
    float lastTime = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastTime >= fireRate)
        {
            // 총알 공장에서 총알 생성
            GameObject bullet = Instantiate(bulletFactory);
            // 총알 위치를 총구 위치로 변경
            bullet.transform.position = firePosition.transform.position;
            // 마지막 발사 시간 갱신
            lastTime = Time.time;
        }
    }
}
