using UnityEngine;
using System;

public class Star : MonoBehaviour, ICollisionable
{
    public event EventHandler OnScoreChanged;

    private AudioSource audioSource;
    private float starDeadZone = 5.45f;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Collision()
    {
        audioSource.Play();
        //score increase.
        OnScoreChanged?.Invoke(this, EventArgs.Empty);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    private void Update()
    {
        if(transform.parent.position.y > starDeadZone)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
