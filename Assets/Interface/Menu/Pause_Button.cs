using UnityEngine;

public class Pause_Button : MonoBehaviour
{
    public GameObject panel;
    public void Pause()
    {
        Debug.Log("Sosi");
        panel.SetActive(true);
        Time.timeScale = 0f;
    }
}
