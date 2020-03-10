using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using TMPro;

public class ButtonActions : MonoBehaviour
{
    public VideoPlayer video;
    public TextMeshProUGUI text;

    public bool isPlaying;

    // Start is called before the first frame u
    void Start()
    {
        isPlaying = true;
        text.text = "Playing";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click()
    {
        Debug.Log("Button Clicked");

        if (isPlaying)
        {
            isPlaying = !isPlaying;
            text.text = "Stoped";
            video.Pause();
        }
        else
        {
            isPlaying = !isPlaying;
            text.text = "Playing";
            video.Play();
        }
    }
}
