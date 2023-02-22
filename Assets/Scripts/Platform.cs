using UnityEngine;

public class Platform : MonoBehaviour,ICollisionable
{
    public float platformSpeed = 7;
    private float _startPlatformYPos = -5.68f;
    private float deadZone = 5.55f;

    [SerializeField] AudioSource audioSource;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, platformSpeed * Time.deltaTime, 0);

        if(transform.position.y >= deadZone)
        {
            transform.position = new Vector3(Random.Range(-2.47f,2.43f), _startPlatformYPos, 0);
        }
    }

    public void Collision()
    {
        audioSource.Play();
    }
}
