using UnityEngine;
using UnityEngine.SceneManagement;

public class Menubuttonsound : MonoBehaviour
{
    public AudioClip clickSfx;    // 버튼 효과음
    public AudioSource audioSource; // (메뉴에 빈 오브젝트에 추가하거나, 버튼 오브젝트에 추가)

    public string sceneToLoad;    // 예: "MainGame"

    public void OnStartButton()
    {
        audioSource.PlayOneShot(clickSfx);   // 효과음 재생
        Invoke(nameof(LoadGameScene), clickSfx.length); // 효과음 끝난 뒤 씬 이동
    }

    void LoadGameScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
