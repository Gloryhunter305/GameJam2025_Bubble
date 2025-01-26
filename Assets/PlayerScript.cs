using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //Components for Gameobject
    public Rigidbody2D RB;
    public Collider2D Coll;     //Interaction with other Gameobjects
    public AudioSource AS;      //Audio for Gameobject 

    //Gameobject's Stats (may change)
    public float Speed = 5;
    public float JumpPower = 10;
    public float Gravity = 1;

    [SerializeField] private int score;

    // Start is called before the first frame update
    void Start()
    {
        RB.gravityScale = Gravity;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vel = RB.velocity;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            vel.x = -Speed;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            vel.x = Speed;
        }
        else
        {
            vel.x = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            vel.y = JumpPower;
        }

        RB.velocity = vel;
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Collectible")
        {
            Debug.Log("Collected a bubble");
            score++;
        }
    }
}
