using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class CorrectItemScript : MonoBehaviour
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

    // Update is called once per frame
    void Update()
    {
        if (isBeingHeld)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePos);

            if (target.GetComponent<Collider2D>().IsTouching(this.gameObject.GetComponent<Collider2D>()))
            {
                DragDrop.score += 1;
                this.gameObject.SetActive(false);
                DragDrop.correctDeleted += 1;
            }

        }
    }
}
