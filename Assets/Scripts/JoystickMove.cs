using UnityEngine;

public class JoystickMove : MonoBehaviour
{
    public float speed = 5;
    public VariableJoystick variableJoystick;
    public Rigidbody rb;

    // Update is called once per frame
    void FixedUpdate()
    {
        // 조이스틱 입력을 받아옴
        float horizontal = variableJoystick.Horizontal;
        // 이동 방향 계산
        Vector3 direction = new Vector3(horizontal, 0, 0).normalized;
        // 속도 설정
        rb.linearVelocity = direction * speed;
    }
}
