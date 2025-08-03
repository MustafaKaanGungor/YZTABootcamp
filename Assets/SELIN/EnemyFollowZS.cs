using UnityEngine;
using UnityEngine.AI;

public class EnemyFollowZS : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;
    private Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();

        // Player'ı otomatik bul
        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
                player = playerObj.transform;
            else
                Debug.LogWarning("Player not found! Make sure they are tagged as 'Player'");
        }
    }

    void Update()
    {
        if (player != null)
        {
            agent.SetDestination(player.position);

            // Animator'a hız bilgisini ver
            float currentSpeed = agent.velocity.magnitude;
            animator.SetFloat("Speed", currentSpeed);
        }
    }
}
