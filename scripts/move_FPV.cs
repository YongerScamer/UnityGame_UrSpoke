using UnityEngine;
using UnityEngine.AI;

public class move_FPV : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    NavMeshAgent agent;
    public GameObject player;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
    }
}
