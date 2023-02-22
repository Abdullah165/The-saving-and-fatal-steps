using UnityEngine;
using System;

public class Spikes : MonoBehaviour, ICollisionable
{
    private AudioSource audioSource;

    public static event EventHandler OnGameOver;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Collision()
    {
        audioSource.Play();
        OnGameOver?.Invoke(this, EventArgs.Empty);
    }
}
