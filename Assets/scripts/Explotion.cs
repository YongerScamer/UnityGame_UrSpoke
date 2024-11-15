using UnityEngine;

public class Explotion : MonoBehaviour
{
    public float timeDestroy = 0.3f;
    void Start()
    {
        Invoke("DestroyExplotion", timeDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DestroyExplotion()
    {
        Destroy(this.gameObject);
    }
}
