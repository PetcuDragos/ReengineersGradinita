using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongItemScript : MonoBehaviour
{
    public GameObject target;
    private bool isBeingHeld = false;

    
    public void OnMouseDown()
    {
        isBeingHeld = true;

    }
    public void OnMouseUp()
    {
        isBeingHeld = false;

    }
    void Update()
    {
        if (isBeingHeld)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePos);

            if (target.GetComponent<Collider2D>().IsTouching(this.gameObject.GetComponent<Collider2D>()))
            {
                DragDrop.score -= 1;
                this.gameObject.SetActive(false);
            }

        }
    }
}
