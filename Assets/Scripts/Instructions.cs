using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instructions : MonoBehaviour
{
    public AudioSource source;
    public AudioClip intro, bucatarS, doctorS, fotografS, judecatorS, programatorS, politistS, mecanicS, pompierS, fermierS, muncitorS;
    public GameObject instructionButton;
    private bool started;
    private int count;
    private AudioClip[] list;
    private float timer = 0f;
    public Queue<int> order = new Queue<int>();

    public int getOrder() {
        return order.Peek();
    }

    public void nextOrder() {
        order.Dequeue();
    }

    public bool hasStarted() {
        return started;
    }

    public void playIntro() {
        source.clip = intro;
        source.Play();
    }

    public void playNext() {
        source.Stop();
        if (count < 10) {
            source.clip = list[count];
            source.Play();
        }
        count += 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        started = false;
        count = 1;
        instructionButton.GetComponent<Button>().onClick.AddListener(() => ReplayInstruction());
        list = new AudioClip[] { bucatarS, doctorS, fotografS, judecatorS, programatorS, politistS, mecanicS, pompierS, fermierS, muncitorS };
        order.Enqueue(1); order.Enqueue(2); order.Enqueue(3); order.Enqueue(4); order.Enqueue(5);
        order.Enqueue(6); order.Enqueue(7); order.Enqueue(8); order.Enqueue(9); order.Enqueue(10);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (35 < timer && timer < 36)
        {
            started = true;
        }
        if (36 < timer && timer < 37) {
            source.Stop();
            source.clip = list[0];
            source.Play();
        }
        return;
    }

    private void ReplayInstruction()
    {
        if (!source.isPlaying)
        {
            source.Play();
        }
    }
}
