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
    public CountMistakes countMistakes;
    public Instructions instructions;
    public int order;

    void Awake() {
        originalPosition = transform.position;
    }

    public void OnMouseDown() 
    {
        if (!instructions.hasStarted()) { return; }
        if (goodSlot.isMatched()){ return; }
        source.PlayOneShot(pickUpClip);
        Debug.Log("OnMouseDown");
        dragging = true;
        offset = GetMousePos() - (Vector2)transform.position;
        
    }

    private IEnumerator SleepOneSec() {
        yield return new WaitForSeconds(1);
        instructions.playNext();
    }

    public void OnMouseUp()
    {
        if (!instructions.hasStarted()) { return; }
        Debug.Log("OnMouseUp");
        if (Vector2.Distance(transform.position, goodSlot.transform.position) < 2)
        {
            if (goodSlot.isMatched()) {
                return;
            }
            if (instructions.getOrder() == order)
            {
                goodSlot.match();
                instructions.nextOrder();
                source.PlayOneShot(correctClip);
                transform.position = goodSlot.transform.position;
                placed = true;
                countMistakes.addMatch();
                StartCoroutine(SleepOneSec());
            }
            else {
                source.PlayOneShot(dropClip);
                transform.position = originalPosition;
                countMistakes.addMistake();
            }
            
        }
        else {
            source.PlayOneShot(dropClip);
            transform.position = originalPosition;
            countMistakes.addMistake();
        }
        dragging = false;
    }


    void Start()
    {
        placed = false;
        instructions.playIntro();
    }

    void Update()
    {
        if (!instructions.hasStarted()) { return; }
        if (placed) { return; }
        if (!dragging) { return; }
        var mousePosition = GetMousePos();
        transform.position = mousePosition - offset;
    }

    Vector2 GetMousePos() {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
