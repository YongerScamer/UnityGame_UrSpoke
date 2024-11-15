using UnityEngine;

public class Robot : MonoBehaviour
{
    public float speed = 7;
    public float health = 20;
    private Animator animator;
    private Rigidbody2D rigidbody;
    public Coll Rground;
    public Coll Lground;
    private bool orientation = true;
    private Vector3 _moveVel;
    bool die = false;
    public GameObject trash;
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!die)
        {
            {

            }
            if (Rground.collide)
            {
                orientation = false;
                Rground.collide = false;
                GetComponent<SpriteRenderer>().flipX = true;
            }
            if (Lground.collide)
            {
                orientation = true;
                Lground.collide = false;
                GetComponent<SpriteRenderer>().flipX = false;
            }
            if (orientation)
            {
                _moveVel = rigidbody.linearVelocity;
                _moveVel.x = speed * Time.fixedDeltaTime;
                rigidbody.linearVelocity = _moveVel;
            }
            else
            {
                _moveVel = rigidbody.linearVelocity;
                _moveVel.x = speed * Time.fixedDeltaTime * -1f;
                rigidbody.linearVelocity = _moveVel;
            }
        }

    }
    public void Damage(int damage)
    {
        if (!die)
        {
            health -= damage;
            Debug.Log(damage);
            if (health <= 0)
            {
                Instantiate(trash, transform.position, new Quaternion(0f, 0f, 0f, 0f));
                Destroy(this.gameObject);
                die = true;
            }
        }
    }
}
