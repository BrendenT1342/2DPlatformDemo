using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2.0f;
    public float jump;
    public Collectable cm;

    [SerializeField] private LayerMask JumpGround;
    private Rigidbody2D character;
    private CapsuleCollider2D colli;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<Rigidbody2D>();
        colli = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // This makes the player to move the character.
        character.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, character.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            character.AddForce(new Vector2(character.velocity.x, jump));
            Debug.Log("Character can jump");
        }
    }

    // Ensure the character is on ground after jumping.
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(colli.bounds.center, colli.bounds.size, 0f, Vector2.down, .1f, JumpGround);
    }

    // When the player touches a box of cigars the cigar will disappear and collected.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Cigar"))
        {
            Destroy(other.gameObject);
            cm.cigarCount++;
            Debug.Log("Cigar collected");
        }
    }
}
