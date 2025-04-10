using UnityEngine;

public class MusicMixer : MonoBehaviour
{
    private string[] trackNames = {
        "Audio/SpaceParanoids",
        "Audio/ByteBashing",
        "Audio/VimandVigor",
        "Audio/13thStruggle"
    };

    public int currentTrack = 0;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayCurrentTrack();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))  // You can press Q to go to the next track
        {
            NextTrack(); // Reuse the public method
        }
    }

    // 🔊 Public method so other scripts (like GameManager) can switch tracks
    public void NextTrack()
    {
        currentTrack = (currentTrack + 1) % trackNames.Length;
        PlayCurrentTrack();
    }

    private void PlayCurrentTrack()
    {
        AudioClip clip = Resources.Load<AudioClip>(trackNames[currentTrack]);
        if (clip != null)
        {
            audioSource.Stop();
            audioSource.clip = clip;
            audioSource.Play();
            Debug.Log("Now playing: " + trackNames[currentTrack]);
        }
        else
        {
            Debug.LogError("Could not load clip: " + trackNames[currentTrack]);
        }
    }
}
