using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public static AudioManager instance;

    [SerializeField] private AudioSource bgmPlayer, sfxPlayer;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public void PlayBGM(string trackName)
    {
        PlayBGM(trackName, 0f);
    }

    public void PlayBGM(string trackName, float time)
    {
        AudioClip track = _GetAudioClip(trackName);

        if (track != null)
        {
            bgmPlayer.Stop();
            bgmPlayer.time = time;
            bgmPlayer.clip = track;
            bgmPlayer.Play();
        }
    }

    public void PlaySFX(string trackName)
    {
        float volume = Random.Range(.75f, 1f);
        PlaySFX(trackName, volume);
    }

    public void PlaySFX(string trackName, float volume)
    {
        AudioClip track = _GetAudioClip(trackName);
        if (track != null)
        {
            sfxPlayer.PlayOneShot(track, volume);
        }
    }

    public void PlayRandomSFX(params string[] trackNames)
    {
        //Debug.Log(trackNames.Length);
        string randomTrack = trackNames[Random.Range(0, trackNames.Length)];
        Debug.Log(randomTrack);

        PlaySFX(randomTrack);
    }

    public void PlayRandomSFX(float volume, params string[] trackNames)
    {
        string randomTrack = trackNames[Random.Range(0, trackNames.Length)];
        Debug.Log(randomTrack);

        PlaySFX(randomTrack, volume);
    }

    // Used to manage Ethan's layering of tracks. Will currently update the stage every level.
    public void PlayNextARQStage()
    {
        float trackTime = bgmPlayer.time;
        string currentTrackName = bgmPlayer.clip.name;
        int currentStageNum = System.Int32.Parse(currentTrackName[currentTrackName.Length - 1].ToString());
        PlayBGM("ARQstage" + (currentStageNum + 1), trackTime);
    }

    private AudioClip _GetAudioClip(string clipName)
    {
        string trackPath = "Sounds/" + clipName;
        AudioClip track = Resources.Load("Sounds/" + clipName) as AudioClip;

        if (track == null)
        {
            Debug.LogErrorFormat("Track [Resources/{0}] not found", trackPath);
        }

        return track;
    }
}
