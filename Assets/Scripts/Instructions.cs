using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    public AudioSource source;
    public AudioClip intro, bucatarS, doctorS, fotografS, judecatorS, programatorS, politistS, mecanicS, pompierS, fermierS, muncitorS;
    private bool started;
    private int count;
    private AudioClip[] list;
    private float timer = 0f;

    public bool hasStarted() {
        return started;
    }

    public void playIntro() {
        source.PlayOneShot(intro);
    }

    public void playNext() {
        source.Stop();
        if (count < 10) {
            source.PlayOneShot(list[count]);
        }
        count += 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        started = false;
        count = 1;
        list = new AudioClip[] { bucatarS, doctorS, fotografS, judecatorS, programatorS, politistS, mecanicS, pompierS, fermierS, muncitorS };
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
            source.PlayOneShot(list[0]);
        }
        return;
    }
}
