using UnityEngine;
using System.Collections;

public class MultiSequenceAudio : MonoBehaviour
{
    public AudioSource[] audioSources;   // 여러 AudioSource 배열
    public float[] delays;               // 각 효과음 전 대기 시간(초)

    void Start()
    {
        StartCoroutine(PlaySequence());
    }

    IEnumerator PlaySequence()
    {
        for (int i = 0; i < audioSources.Length; i++)
        {
            if (i < delays.Length)
                yield return new WaitForSeconds(delays[i]);

            if (audioSources[i])
                audioSources[i].Play();
        }
    }
}
