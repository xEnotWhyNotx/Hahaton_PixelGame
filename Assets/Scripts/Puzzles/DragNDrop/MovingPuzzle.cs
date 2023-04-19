using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPuzzle : MonoBehaviour
{
    private bool move;
    private Vector2 mousePos;
    private float startPosX;
    private float startPosY;
    public GameObject form;
    private bool finish;

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            move = true;
            mousePos = Input.mousePosition;

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;
        }
    }

    void OnMouseUp()
    {
        move = false;


        if (Mathf.Abs(this.transform.localPosition.x - form.transform.localPosition.x) <= 5f &&
           Mathf.Abs(this.transform.localPosition.y - form.transform.localPosition.y) <= 5f && finish != true)
        {
            this.transform.position = new Vector2(form.transform.position.x, form.transform.position.y);
            finish = true;
            WinScript.AddElement();
        }
    }

    private void Update()
    {
        if (move == true && finish == false)
        {
            mousePos = Input.mousePosition;
            this.gameObject.transform.localPosition = new Vector2(mousePos.x - startPosX, mousePos.y - startPosY);
        }
    }
}
