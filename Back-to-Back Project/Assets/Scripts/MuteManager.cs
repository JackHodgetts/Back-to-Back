using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;

public class MuteManager : MonoBehaviour
{
    public Sprite muteImage;
    public Sprite audioImage;
    public Button button;
    private bool isPlaying = true;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioImage = button.image.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Mute()
    {
        if (isPlaying)
        {
            button.image.sprite = muteImage;
            isPlaying = false;
            audioSource.mute = true;
        }
        else
        {
            button.image.sprite = audioImage; 
            isPlaying = true;
            audioSource.mute = false;
        }
    }
}
