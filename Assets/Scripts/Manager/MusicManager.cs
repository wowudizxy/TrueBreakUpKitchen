using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private const string MUSICMANAGER_VOLUME = "MusicManagerVolume"; 
    public static MusicManager Instance { get; private set; }
    private AudioSource musicSource;
    private float sourceVolume;
    private int volume = 6;
    private void Awake()
    {
        Instance = this;
        SetVolume();
    }
    private void Start()
    {
        musicSource = GetComponent<AudioSource>();
        sourceVolume = musicSource.volume;
        UpdateVolume();
    }
    private void UpdateVolume()
    {
        if (volume == 0)
        {
            musicSource.enabled = false;
        }
        else
        {
            musicSource.enabled = true;
            musicSource.volume = sourceVolume * (volume / 10f);
        }
        
    }
    public void ChangeVolume()
    {
        volume++;
        if (volume > 10)
        {
            volume = 0;
        }
        SaveVolume();
        UpdateVolume();
    }
    public int GetVolume()
    {
        return volume;
    }
    private void SaveVolume()
    {
        PlayerPrefs.SetInt(MUSICMANAGER_VOLUME, volume);
    }
    private void SetVolume()
    {
        volume=PlayerPrefs.GetInt(MUSICMANAGER_VOLUME, volume);
    }

}
