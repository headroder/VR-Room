using UnityEngine;
using System.Collections;

public class AutoTeleport : MonoBehaviour
{
    public Transform player;      // XR Rig 등 이동시킬 대상
    public Transform targetSpot;  // 이동할 목표 위치(빈 오브젝트 등)
    public float delay = 5.0f;    // 텔레포트까지 대기 시간(초)

    void Start()
    {
        StartCoroutine(TeleportAfterDelay());
    }

    IEnumerator TeleportAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        if (player && targetSpot)
        {
            player.position = targetSpot.position;
            player.rotation = targetSpot.rotation;
        }
    }
}
