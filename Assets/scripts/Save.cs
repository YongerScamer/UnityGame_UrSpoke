using UnityEngine;
using UnityEngine.SceneManagement;
public class Save : MonoBehaviour
{
    public string les;

    public void save()
    {
        PlayerPrefs.SetString("les", les);
    }

    public void load()
    {
        les = PlayerPrefs.GetString("les");
        SceneManager.LoadScene(les);
    }
}
