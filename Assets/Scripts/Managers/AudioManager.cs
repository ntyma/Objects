using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private Player player;
    [SerializeField] private AudioSource shootAudio;
    [SerializeField] private AudioSource throwAudio;

    public void Start()
    {
        player = FindObjectOfType<Player>();
        player.OnShoot.AddListener(PlayShootAudio);
        player.OnThrow.AddListener(PlayThrowAudio);
    }

    public void PlayShootAudio()
    {
        shootAudio.Play();
    }

    public void PlayThrowAudio()
    {
        throwAudio.Play();
    }
}
