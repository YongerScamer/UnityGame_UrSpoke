using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMenu_Button : MonoBehaviour
{
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1.0f;
    }
}
