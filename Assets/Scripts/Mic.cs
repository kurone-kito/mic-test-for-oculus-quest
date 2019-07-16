using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Mic : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject text;

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
        transform.localScale = Vector3.one * (level + 1) * 3;
        var txt = text.GetComponent<Text>();
        txt.text = level.ToString();
    }
}
