using UnityEngine;

public class NextLevel : MonoBehaviour 
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        LevelController.instance.isEndGame();
    }
}
