using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelTransition
{
    public void changeScene(int scene)
    {
        SceneManager.LoadScene(scene); 
    }
}
