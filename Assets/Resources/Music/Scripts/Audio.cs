using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Sprite audioOn;
    public Sprite audioOff;
    public GameObject buttonAudio;

    public Scrollbar scrollbar;

    public AudioSource backgroundAudio; // Фоновая музыка

    private void Start()
    {
        backgroundAudio.loop = true;
        backgroundAudio.Play();
    }

    private void Update()
    {
        backgroundAudio.volume = scrollbar.value;
    }

    public void ToggleAudio()
    {
        if (backgroundAudio.mute)
        {
            backgroundAudio.mute = false;
            buttonAudio.GetComponent<Image>().sprite = audioOn;
        }
        else
        {
            backgroundAudio.mute = true;
            buttonAudio.GetComponent<Image>().sprite = audioOff;
        }
    }
}