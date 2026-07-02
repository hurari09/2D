using UnityEngine;

public class Background : MonoBehaviour
{
    // 배경 Material 변수
    public Material bgMaterial;
    // 배경 스크롤 속도 변수
    public float scrollSpeed = 0.2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 방향 벡터 생성
        Vector2 dir = Vector2.up;
        // 스크롤 속도 적용
        bgMaterial.mainTextureOffset += dir * scrollSpeed * Time.deltaTime;
    }
}
