using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Piece : MonoBehaviour
{
    private bool dragging, placed;
    private Vector2 offset, originalPosition;
    public Slot goodSlot;
    public  AudioSource source;
    public AudioClip pickUpClip, dropClip, correctClip;
    public int greseli;

    void Awake() {
        originalPosition = transform.position;
    }

    public void OnMouseDown() 
    {
        source.PlayOneShot(pickUpClip);
        Debug.Log("OnMouseDown");
        dragging = true;
        offset = GetMousePos() - (Vector2)transform.position;
        
    }

    public void OnMouseUp()
    {
        Debug.Log("OnMouseUp");
        if (Vector2.Distance(transform.position, goodSlot.transform.position) < 1)
        {
            source.PlayOneShot(correctClip);
            transform.position = goodSlot.transform.position;
            placed = true;
        }
        else {
            source.PlayOneShot(dropClip);
            transform.position = originalPosition;
            greseli += 1;
        }
        dragging = false;
    }


    void Start()
    {
        placed = false;
        greseli = 0;
    }

    void Update()
    {
        if (placed) { return; }
        if (!dragging) { return; }
        var mousePosition = GetMousePos();
        transform.position = mousePosition - offset;
    }

    Vector2 GetMousePos() {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
