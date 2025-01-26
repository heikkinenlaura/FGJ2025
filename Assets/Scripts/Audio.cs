using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioClip backgroundMusic;

    public AudioClip bubbleWrap;
    public AudioClip coffeeAudio;
    public AudioClip skumpAudio;
    public AudioClip waffleAudio;
    public AudioClip teaAudio;
    public AudioClip happyAudio;
    public AudioClip angryAudio;
    public AudioClip walkAudio;

    private AudioSource audioSource;

    private void Awake()
    {
        // Get or add an AudioSource to this GameObject
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.loop = true;
    }

    public void PlayBackgroundMusic()
    {
        audioSource.clip = backgroundMusic;
        audioSource.Play();

        audioSource.loop = true;
    }

    // Function to play a specific sound
    public void PlaySound(AudioClip clip, float volume = 1.0f)
    {
        if (clip != null)
        {
            audioSource.PlayOneShot(clip, volume);
        }
        else
        {
            Debug.LogWarning("Audio clip is null!");
        }
    }

    public void PlayBubbleSound() => PlaySound(bubbleWrap);
    public void PlayCoffeeSound() => PlaySound(coffeeAudio);
    public void PlaySkumpSound() => PlaySound(skumpAudio);
    public void PlayWaffleSound() => PlaySound(waffleAudio);
    public void PlayHappySound() => PlaySound(happyAudio);
    public void PlayAngrySound() => PlaySound(angryAudio);
    public void PlayTeaSound() => PlaySound(teaAudio);
    public void PlayWalkSound() => PlaySound(walkAudio);

}
