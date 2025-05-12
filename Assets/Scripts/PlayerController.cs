using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRb;
    private Animator anim;
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver;
    public GameManager manager;
    public TextMeshProUGUI gameOverText;
    bool isJumping;
    public GameObject restart;
    public PauseMenu pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isJumping && isOnGround)
        { 
            //playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); 
            isOnGround = false;
            anim.SetTrigger("Jump");
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            gameOverText.gameObject.SetActive(true);
            EventSystem.current.SetSelectedGameObject(restart);
        }
        if(other.gameObject.CompareTag("Score Trigger"))
        {
            manager.AddScore();
        }
    }

    public void OnJump(InputValue value)
    {
        isJumping = value.isPressed;
    }

    public void OnPause(InputValue value)
    {
        pauseMenu.PauseGame();
    }

    public void JumpInput(bool value)
    {
        isJumping = value;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position, transform.forward * 500f);
    }
}
