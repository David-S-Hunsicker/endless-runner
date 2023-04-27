using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float force = 5;
    [SerializeField] Transform raycastOrigin;
    [SerializeField] private bool grounded;
    [SerializeField] Animator anim;
    [SerializeField] UIController uiController;
    [SerializeField] SFXManager sfxManager;

    private RaycastHit2D hit;
    private bool jump;
    float lastY, currentY;
    public float distanceTraveled = 0;
    private bool dead = false;
    public int collectedCoins = 0;

    private void Start()
    {
        dead = false;
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            jump = true;
            anim.SetTrigger("Jump");
        }
        distanceTraveled += Time.deltaTime;

    }

    private void FixedUpdate()
    {
        // Jump and falling
        lastY = currentY;
        currentY = transform.position.y;
        if (lastY > currentY) { anim.SetBool("Falling", true); }
        else { anim.SetBool("Falling", false); }

        hit = Physics2D.Raycast(raycastOrigin.position, Vector2.down);
        grounded = hit.collider != null && hit.distance < 0.1f;

        // Running or Falling
        if (grounded) { anim.SetBool("IsGrounded", true); }
        else { anim.SetBool("IsGrounded", false); }

        if (jump) { rb.AddForce(new Vector2(0, force), ForceMode2D.Impulse); jump = false; }

        if (transform.position.y < -5 && !dead)
        {
            dead = true;
            uiController.ShowGameOverScreen();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectable"))
        {
            Destroy(collision.gameObject);
            collectedCoins++;
            sfxManager.PlaySFX("Coin");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Obstacle"))
        {
            uiController.ShowGameOverScreen();
            Debug.Log("collider death worked.");
        }
    }


}
