using System.Collections;
using UnityEngine;

public class Crack : MonoBehaviour,ICollisionable
{
    private Animator animator;
    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(transform.position.y >= 5.40f)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<Collider2D>().enabled = true;
            animator.SetBool("isCrack", false);
        }
    }
    
    IEnumerator PlatformCrack()
    {
        yield return new WaitForSeconds(1f);
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
    }

    public void Collision()
    {
        StartCoroutine(PlatformCrack()); 
        animator.SetBool("isCrack", true);
        audioSource.Play();
    }
}
