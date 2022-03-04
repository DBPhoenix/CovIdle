using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Range(0, 1)]
    public float MasterVolume;

    [HideInInspector]
    public bool BackgroundMusicActive
    {
        get => !BackgroundMusic.mute;
        set => BackgroundMusic.mute = !value;
    }

    [HideInInspector]
    public AudioSource BackgroundMusic;

    private List<AudioSourceSettings> _settings = new List<AudioSourceSettings>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        BackgroundMusic = GetComponent<AudioSource>();

        SceneManager.sceneLoaded += LoadAudioSources;

        DontDestroyOnLoad(gameObject);
    }

    public void SetVolume(float value)
    {
        MasterVolume = value;

        RefreshVolume();
    }

    private void LoadAudioSources(Scene scene, LoadSceneMode mode)
    {
        AudioSource[] newSources = Resources.FindObjectsOfTypeAll<AudioSource>();

        foreach (AudioSource source in newSources)
        {
            _settings.Add(new AudioSourceSettings(source, source.volume));
        }

        RefreshVolume();
    }

    private void RefreshVolume()
    {
        foreach (AudioSourceSettings setting in _settings)
        {
            if (setting.Source == null)
            {
                continue;
            }

            setting.Source.volume = setting.InitialVolume * (MasterVolume / 0.5f);
        }
    }
}

struct AudioSourceSettings
{
    public AudioSource Source;

    public float InitialVolume;

    public AudioSourceSettings(AudioSource source, float initialVolume)
    {
        Source = source;
        InitialVolume = initialVolume;
    }
}
