using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Mic : MonoBehaviour
{
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.loop = true;
        audioSource.clip = Microphone.Start(null, true, 10, 44100);
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        var data = new float[256];
        audioSource.GetOutputData(data, 0);
        var level = data.Aggregate((a, c) => a + Mathf.Abs(c)) / data.Length;
        Debug.Log(level);
    }
}
