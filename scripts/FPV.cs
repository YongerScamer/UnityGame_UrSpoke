using UnityEngine;
using UnityEngine.AI;

public class FPV : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    NavMeshAgent agent;
    Player player;
    Rigidbody2D rig;
    bool die;
    Animator animator;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        player = FindAnyObjectByType<Player>();
        rig = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        die = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!die)
        {
            if ((transform.position - player.transform.position).magnitude < 3)
            {
                player.Damage(20);
                rig.gravityScale = 1;
                Destroy(agent);
                Destroy(animator);
                die = true;
            }
            else
            {
                agent.SetDestination(player.transform.position);
                transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
            }
        }
    }
}
