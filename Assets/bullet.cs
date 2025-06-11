using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 5f;  // 총알이 5초 후 자동으로 사라짐

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // 충돌하면 바로 사라짐
        Destroy(gameObject);
        // 여기서 맞은 대상에 효과/점수/이펙트 등도 처리 가능
    }
}
