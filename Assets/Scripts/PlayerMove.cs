using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float feverSpeed;
    public int hp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        feverSpeed = 1f;
        hp = 3;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 dir = Vector3.right * h + Vector3.up * v;
        transform.Translate(dir * 5 * Time.deltaTime * feverSpeed);
    }
}
