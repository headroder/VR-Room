using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [Header("Settings Panel")]
    public GameObject settingsPanel;

    [Header("Audio Controls")]
    public Slider volumeSlider;
    public Toggle sfxToggle;

    private void Start()
    {
        // 기본 설정 적용
        volumeSlider.onValueChanged.AddListener(SetVolume);
        sfxToggle.onValueChanged.AddListener(SetSFX);
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    private void SetVolume(float value)
    {
        // 오디오 볼륨 설정 (배경 음악용)
        AudioListener.volume = value;
    }

    private void SetSFX(bool isOn)
    {
        // 사운드 효과 설정 (예: 효과음 on/off 플래그)
        PlayerPrefs.SetInt("SFX_ON", isOn ? 1 : 0);
    }
}
