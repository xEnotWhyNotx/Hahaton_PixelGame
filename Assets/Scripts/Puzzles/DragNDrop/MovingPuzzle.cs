using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovingPuzzle : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public GameObject form;
    private bool finish;
    
    public void OnDrag(PointerEventData eventData)
    {
        if (!finish)
        {
            this.gameObject.transform.localPosition += new Vector3(eventData.delta.x * (1920.0f / Screen.width), eventData.delta.y * (1080.0f / Screen.height), 0);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        if (Mathf.Abs(this.transform.localPosition.x - form.transform.localPosition.x) <= 20f &&
            Mathf.Abs(this.transform.localPosition.y - form.transform.localPosition.y) <= 20f && !finish)
        {
            this.transform.position = new Vector2(form.transform.position.x, form.transform.position.y);
            finish = true;
            WinScript.AddElement();

        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }


}
