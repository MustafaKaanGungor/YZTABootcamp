using UnityEngine;

public class WeaponShooter : MonoBehaviour
{
    [Header("Projectile Settings")]
    public GameObject projectilePrefab;         // F�rlat�lacak mermi prefab�
    public Transform projectileSpawnPoint;      // Merminin ��kaca�� nokta
    public float projectileSpeed = 20f;         // Mermi h�z�

    [Header("Effects")]
    public GameObject muzzleEffectPrefab;       // Muzzle efekt prefab�
    public Transform muzzleEffectSpawnPoint;    // Muzzle efektin ��kaca�� nokta

    public void Fire()
    {
        SpawnProjectile();
        PlayMuzzleEffect();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    private void SpawnProjectile()
    {
        if (projectilePrefab == null || projectileSpawnPoint == null)
            return;

        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = projectileSpawnPoint.forward * projectileSpeed; 
           

        }
    }

    private void PlayMuzzleEffect()
    {
        if (muzzleEffectPrefab == null || muzzleEffectSpawnPoint == null)
            return;

        GameObject effect = Instantiate(muzzleEffectPrefab, muzzleEffectSpawnPoint.position, muzzleEffectSpawnPoint.rotation);
        // Efekti belli bir s�re sonra yok et (�rn. 2 sn)
        Destroy(effect, 2f);
    }
}
