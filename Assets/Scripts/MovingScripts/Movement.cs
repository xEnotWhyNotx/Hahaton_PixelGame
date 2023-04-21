using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    private bool f;
    public Animator animator;
    private Vector3 direction;

    private float horizontal;
    private float vertical;

    private void Awake()
    {
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
        direction = new Vector3(0, 1);
        this.transform.position += direction * speed * Time.deltaTime;
        AnimateMovement(direction);
    }
    public void Stop()
    {
        direction = new Vector3(0, 0);
        this.transform.position += direction * speed * Time.deltaTime;
        AnimateMovement(direction);
    }
    public void Down()
    {
        direction = new Vector3(0, -1);
        this.transform.position += direction * speed * Time.deltaTime;
        AnimateMovement(direction);
    }
    public void Left()
    {
        direction = new Vector3(-1, 0);
        this.transform.position += direction * speed * Time.deltaTime;
        AnimateMovement(direction);
    }
    public void Right()
    {
        direction = new Vector3(1, 0);
        this.transform.position += direction * speed * Time.deltaTime;
        AnimateMovement(direction);
    }
}