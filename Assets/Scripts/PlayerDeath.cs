using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D cha;
    public LayerMask rayMask;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //If a player fall into a pit with spikes under water.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //When a player fall into a pit of spikes underwater.
        if (collision.gameObject.CompareTag("Spike"))
        {
            Death();
            Debug.Log("Game Over");
        }

        // When an player touches the enemy it dies. The player must avoid touching the enemy.
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            Debug.Log("Game Over");
        }
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 100f, rayMask);
        if (hit.collider != null)
        {
            Destroy(hit.transform.gameObject);
            return;
            
        }
        
    }

    // This will disable the movement of the sprite charcater after getting killed by underwater spikes or enemy.
    void Death()
    {
        // This will not only destroy the player object, but won't allow player to move.
        //rb.bodyType = RigidbodyType2D.Static;

        // This will destroy the object(Player).
        Destroy(gameObject);
    }
}
