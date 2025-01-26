using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Vector3 respawnPoint;

    private PlayerScript player;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerScript>();
    }

    public void RespawnNow()
    {
        transform.position = respawnPoint;
    }

    private void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            RespawnNow();
            player.Health -= 1;
        }
    }
}
