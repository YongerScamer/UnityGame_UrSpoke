using UnityEngine;
using UnityEngine.UI;
public class AudioController : MonoBehaviour 
{
    public Sprite audiOn;
    public Sprite audiOff;
    public GameObject buttonAudio;

    public Slider slider;

    public AudioClip clip;
    public AudioSource audio;

    private void Update()
    {
        audio.volume = slider.value;
    }
    public void OnOffAudio()
    {
        if (AudioListener.volume == 1)
        {
            AudioListener.volume = 0;
            buttonAudio.GetComponent<Image>().sprite = audiOff;
        }
        else
        {
            AudioListener.volume = 1;
            buttonAudio.GetComponent<Image>().sprite = audiOn;
        }
    }
    public void PlaySound()
    {
        audio.PlayOneShot(clip);
    }
}
