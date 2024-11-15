using UnityEngine;

public class Coll : MonoBehaviour
{
    public bool collide = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("pupu");
        if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "FPV" || collision.gameObject.tag == "Robot" || collision.gameObject.tag == "Walls")
        {
            collide = true;
        }
    }
}
