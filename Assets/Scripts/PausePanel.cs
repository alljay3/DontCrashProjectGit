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

    public void ToggelMusic(bool enabled)
    {
        if (enabled)
            _mixer.audioMixer.SetFloat("MusicVolume", 1);
        else
            _mixer.audioMixer.SetFloat("MusicVolume", 0);
    }

    public void ChangeVolume(int volume)
    {
        _mixer.audioMixer.SetFloat("MasterVolume", Mathf.Lerp(-80, 0, volume));
    }
}
