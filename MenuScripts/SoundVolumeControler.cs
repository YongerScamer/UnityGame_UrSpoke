using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SoundVolumeControler : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private AudioSource audio;
    [SerializeField] private Slider slider;
    [SerializeField] private Text text;

    [Header("Keys")]

    [SerializeField] private string saveVolumeKey;

    [Header("Parametrs")]
    [SerializeField] private float volume;

    [Header("Tags")]
    [SerializeField] private string sliderTag;
    [SerializeField] private string textVolumeTag;

    private void Awake()
    {
        if (PlayerPrefs.HasKey(this.saveVolumeKey))
        {
            this.volume = PlayerPrefs.GetFloat(this.saveVolumeKey);
            this.audio.volume = this.volume;

            GameObject Sliderobj = GameObject.FindWithTag(this.sliderTag);
            if (Sliderobj != null)
            {
                this.slider = Sliderobj.GetComponent<Slider>();
                this.slider.value = this.volume;
            }
        }
        else
        {
            this.volume = 0.5f;
            PlayerPrefs.SetFloat(this.saveVolumeKey, this.volume);
            this.audio.volume = this.volume;
        }
    }
    private void LateUpdate()
    {
        GameObject Sliderobj = GameObject.FindWithTag(this.sliderTag);
        if (Sliderobj != null)
        {
            this.slider = Sliderobj.GetComponent<Slider>();
            this.volume = slider.value;

            if (this.audio.volume != this.volume)
            {
                PlayerPrefs.SetFloat(this.saveVolumeKey, this.volume);
            }

            GameObject textobj = GameObject.FindWithTag(this.textVolumeTag);
            if (textobj != null)
            {
                this.text = textobj.GetComponent<Text>();

                this.text.text = Mathf.Round(f: this.volume * 100) + "%";
            }
        }
        this.audio.volume = this.volume;
    }
}
