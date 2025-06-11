using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class GunController : MonoBehaviour
{

    public AudioSource audioSource;

    public ParticleSystem muzzleFlash;

    public AudioClip fireSfx;
    [Header("Input Actions")]
    public InputActionProperty triggerAction; // 트리거(발사)
    public InputActionProperty gripAction;    // 그립(장전)

    [Header("Bullet")]
    public GameObject bulletPrefab;
    public Transform firePoint;


    public float bulletForce = 40f;
    public int maxAmmo = 10;
    private int currentAmmo;

    private XRGrabInteractable grabInteractable;

    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        currentAmmo = maxAmmo;
    }

    void OnEnable()
    {
        grabInteractable.selectEntered.AddListener(OnGrabbed);
        grabInteractable.selectExited.AddListener(OnReleased);
    }

    void OnDisable()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrabbed);
        grabInteractable.selectExited.RemoveListener(OnReleased);
        triggerAction.action.Disable();
        gripAction.action.Disable();
    }

    void OnGrabbed(SelectEnterEventArgs args)
    {
        triggerAction.action.Enable();
        gripAction.action.Enable();
    }

    void OnReleased(SelectExitEventArgs args)
    {
        triggerAction.action.Disable();
        gripAction.action.Disable();
    }

    void Update()
    {
        if (!grabInteractable.isSelected) return;

        // Fire
        if (triggerAction.action.WasPressedThisFrame())
        {
            Fire();
        }

        // Reload
        if (gripAction.action.WasPressedThisFrame())
        {
            Reload();
        }
    }

   public void Fire()
{
    Debug.Log("Fire() called!");  // 추가
    if (currentAmmo <= 0)
    {
        Debug.Log("Out of Ammo! Reload.");
        Reload();
        return;
    }

    if (audioSource && fireSfx)
        audioSource.PlayOneShot(fireSfx);

    if (muzzleFlash) muzzleFlash.Play();

    var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    Debug.Log("Bullet instantiated: " + bullet);
    var rb = bullet.GetComponent<Rigidbody>();
    if (rb != null)
    {
        rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
        Debug.Log("Force applied to bullet");
    }
    else
    {
        Debug.LogError("No Rigidbody found on bullet!");
    }

    currentAmmo--;
    Debug.Log($"Bang! Ammo: {currentAmmo}/{maxAmmo}");

    if (currentAmmo <= 0)
    {
        Debug.Log("Ammo is 0. Auto Reload!");
        Reload();
    }
}


    public void Reload()
    {
        currentAmmo = maxAmmo;
        Debug.Log("Reloaded!");
    }


    

}
