using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float timeDestroy = 1f;
    public float speed = 3f;
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ - 90);

        rb.linearVelocity = transform.up * speed;
        Invoke("DestroyBullet", timeDestroy);
    }

    void DestroyBullet()
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "FPV")
        {
            Debug.Log("Goida");
            collision.gameObject.GetComponent<FPV>().Damage(20);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Robot")
        {
            Debug.Log("Goida");
            collision.gameObject.GetComponent<Robot>().Damage(20);
            Destroy(this.gameObject);
        }
    }
}