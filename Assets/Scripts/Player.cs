using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField] float moveSpeed = 5f;

    private float deadZone = -6f;

    public event EventHandler OnPlayerDead;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.position += moveSpeed * Time.deltaTime * Vector3.left;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) 
        {
            transform.position += moveSpeed * Time.deltaTime * Vector3.right;
        }

        if(transform.position.y < deadZone)
        {
            OnPlayerDead?.Invoke(this, EventArgs.Empty);
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        ICollisionable collisionable = collision.gameObject.GetComponent<ICollisionable>();

        if(collisionable != null)
        {
            collisionable.Collision();
        }
    }
}
