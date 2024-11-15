using UnityEngine;
using UnityEngine.AI;

public class FPV : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    NavMeshAgent agent;
    Player player;
    Rigidbody2D rig;
    Animator animator;
    public int health = 20;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        player = FindAnyObjectByType<Player>();
        rig = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health > 0)
        {
            if ((transform.position - player.transform.position).magnitude < 3)
            {
                health = 0;
                player.Damage(20);
                rig.gravityScale = 3;
                Destroy(agent);
                Destroy(animator);
                GetComponent<Rigidbody>().freezeRotation = false;
            }
            else if ((transform.position - player.transform.position).magnitude < 50)
            {
                agent.SetDestination(player.transform.position);
                transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
            }
        }
    }
    public void Damage(int damage)
    {
        if (health > 0)
        {
            health -= damage;
            Debug.Log(damage);
            if (health <= 0)
            {
                rig.gravityScale = 3;
                EnemyCount.enemys += 1;
                Destroy(agent);
                Destroy(animator);
                GetComponent<Rigidbody>().freezeRotation = false;
            }
        }
    }
}
