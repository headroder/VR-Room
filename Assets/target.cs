using UnityEngine;

public class Target : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip hitSfx;

    private Renderer rend;
    private Color originalColor;

    void Start()
    {
        rend = GetComponent<Renderer>();
        if (rend != null)
            originalColor = rend.material.color;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // 사운드 재생
            if (audioSource && hitSfx)
                audioSource.PlayOneShot(hitSfx);

            // 색상 피드백
            if (rend != null)
            {
                rend.material.color = Color.red; // 맞으면 빨갛게
                Invoke(nameof(RestoreColor), 0.2f); // 0.2초 후 원래 색으로
            }

            // Debug 로그
            Debug.Log("Target Hit!");

            Destroy(collision.gameObject); // 총알 제거
        }
    }

    void RestoreColor()
    {
        if (rend != null)
            rend.material.color = originalColor;
    }
}
