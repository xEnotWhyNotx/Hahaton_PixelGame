using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    private bool f;
    public Animator animator;
    private Vector3 direction;

    private GameObject player;
    private AudioSource audioSource;

    private float horizontal;
    private float vertical;
    

    private void Awake()
    {
        player = GameObject.FindWithTag("Player"); 
        audioSource = player.GetComponent<AudioSource>();

        if (FindObjectOfType<Mobile>() != null)
        {
            f = FindObjectOfType<Mobile>().GetMode();
        }
        else
        {
            f = false;
        }
    }

    private void Update()
    {
        if (Inventory_UI.isActive == true)
        {
            animator.SetBool("isMoving", false);
            return;
        }
        if (DialogueManager.isActive == true)
        {
            animator.SetBool("isMoving", false);
            return;
        }
        if (FindObjectOfType<ActivePuzzle>().GetPuzzle() == true)
        {
            animator.SetBool("isMoving", false);
            return;
        }
        if (f == false)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
        }
        else
        {
            return;
        }
        //Debug.Log("Movement (" + horizontal + ", " + vertical + ")");
        direction = new Vector3(horizontal, vertical);
        AnimateMovement(direction);
    }
    private void FixedUpdate()
    {
        if (Inventory_UI.isActive == true)
        {
            return;
        }
        if (DialogueManager.isActive == true)
        {
            return;
        }
        this.transform.position += direction * speed * Time.deltaTime;
    }

    void AnimateMovement(Vector3 direction)
    {
        if (animator != null)
        {
            if (direction.magnitude > 0)
            {
                animator.SetBool("isMoving", true);
                if (audioSource.isPlaying) return;
                audioSource.Play();
                animator.SetFloat("horizontal", direction.x);
                animator.SetFloat("vertical", direction.y);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }
        }
        
    }

    public void Up()
    {
        if (Inventory_UI.isActive == true)
        {
            animator.SetBool("isMoving", false);
            return;
        }
        direction = new Vector3(0, 1);
        this.transform.position += direction * speed * Time.deltaTime;
        AnimateMovement(direction);
    }
    public void Stop()
    {
        if (Inventory_UI.isActive == true)
        {
            animator.SetBool("isMoving", false);
            return;
        }
        direction = new Vector3(0, 0);
        this.transform.position += direction * speed * Time.deltaTime;
        AnimateMovement(direction);
    }
    public void Down()
    {
        if (Inventory_UI.isActive == true)
        {
            animator.SetBool("isMoving", false);
            return;
        }
        direction = new Vector3(0, -1);
        this.transform.position += direction * speed * Time.deltaTime;
        AnimateMovement(direction);
    }
    public void Left()
    {
        if (Inventory_UI.isActive == true)
        {
            animator.SetBool("isMoving", false);
            return;
        }
        direction = new Vector3(-1, 0);
        this.transform.position += direction * speed * Time.deltaTime;
        AnimateMovement(direction);
    }
    public void Right()
    {
        if (Inventory_UI.isActive == true)
        {
            animator.SetBool("isMoving", false);
            return;
        }
        direction = new Vector3(1, 0);
        this.transform.position += direction * speed * Time.deltaTime;
        AnimateMovement(direction);
    }
}