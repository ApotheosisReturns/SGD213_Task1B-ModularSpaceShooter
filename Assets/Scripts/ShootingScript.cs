using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float fireDelay = 1f;

    private float lastFiredTime;
    private float bulletOffset;

    private Renderer playerRenderer;
    private Renderer bulletRenderer;

    private void Awake()
    {
        playerRenderer = GetComponent<Renderer>();
        bulletRenderer = bullet.GetComponent<Renderer>();
    }

    private void Start()
    {
        // Calculate spawn offset once
        bulletOffset = (playerRenderer.bounds.size.y * 0.5f) +
                       (bulletRenderer.bounds.size.y * 0.5f);
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && CanFire())
        {
            Fire();
        }
    }

    private bool CanFire()
    {
        return Time.time - lastFiredTime >= fireDelay;
    }

    private void Fire()
    {
        Vector2 spawnPosition = new Vector2(
            transform.position.x,
            transform.position.y + bulletOffset
        );

        Instantiate(bullet, spawnPosition, transform.rotation);
        lastFiredTime = Time.time;
    }
}