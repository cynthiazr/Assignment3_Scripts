using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip PlayerHitSound, PlayerCatchSound, PlayerJumpSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        PlayerHitSound = Resources.Load<AudioClip>("PlayerHit");
        PlayerCatchSound = Resources.Load<AudioClip>("PlayerCatch");
        PlayerJumpSound = Resources.Load<AudioClip>("PlayerJump");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "PlayerHit":
                audioSrc.PlayOneShot(PlayerHitSound);
                break;
            case "PlayerCatch":
                audioSrc.PlayOneShot(PlayerCatchSound);
                break;
            case "PlayerJump":
                audioSrc.PlayOneShot(PlayerJumpSound);
                break;
        }
    }
}
