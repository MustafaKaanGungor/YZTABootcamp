using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1;
    public float lifeTime = 3f;

    void Start()
    {
        // 3 saniye sonra kendini yok et
        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        ZombieHealth zombie = collision.gameObject.GetComponent<ZombieHealth>();
        if (zombie != null)
        {
            zombie.TakeDamage(damage);
        }

        // Hemen silinmesini istiyorsan bunu açık bırak:
        Destroy(gameObject);
    }
}
