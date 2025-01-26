using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    //Components for Gameobject
    public Rigidbody2D RB;
    public Collider2D Coll;     //Interaction with other Gameobjects
    public AudioSource AS;      //Audio for Gameobject 

    //Gameobject's Stats (may change)
    public int Health = 3;
    public float Speed = 5;
    public float JumpPower = 10;
    public float Gravity = 1;

    //GameObject's State
    public bool OnGround = false;
    public bool FacingLeft = false;
    public List<GameObject> touching;

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

        if (Input.GetKeyDown(KeyCode.Space) && CanJump())
        {
            vel.y = JumpPower;
        }

        RB.velocity = vel;

        //Game Over Condition: Lose all health before reaching the end
        if (Health == 0)
        {
            SceneManager.LoadSceneAsync(2); //GameOverScene Index
        } 
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Collectible")
        {
            Debug.Log("Collected a bubble");
            score++;
        }
        
        if (other.CompareTag("Win"))    //If player touches geyser
        {
            if (score > 9)
            {
                SceneManager.LoadSceneAsync(3);     //WinScreen Index
            }
            else
            {
                Debug.Log("Not enough bubbles to reach win screen.");
            }
        }
    }

    public bool CanJump()
    {
        return touching.Count > 0;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        OnGround = true;
        touching.Add(other.gameObject);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        OnGround = false;
        touching.Remove(other.gameObject);
    }
}
