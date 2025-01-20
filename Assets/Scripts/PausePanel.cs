using UnityEngine;
using UnityEngine.Audio;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;
    private void OnEnable()
    {
        Time.timeScale = 0f;
    }

    private void OnDisable()
    {
        Time.timeScale = 1f;
    }

    public void ToggelMusic(bool isOn)
    {
        if (isOn)
            _mixer.audioMixer.SetFloat("MusicVolume", 0);
        else
            _mixer.audioMixer.SetFloat("MusicVolume", -80);
    }

    public void ChangeVolume(float volume)
    {
        _mixer.audioMixer.SetFloat("MasterVolume", Mathf.Lerp(-80, 0, volume));
        Debug.Log(volume);
    }
}
