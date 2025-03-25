using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.Sprites;

public class PauseController : MonoBehaviour
{
    private VideoPlayer player;
    public Button button;
    public Sprite startSprite;
    public Sprite stopSprite;
    public AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        if(player.isPlaying == false)
        {
            player.Play();
            button.image.sprite = stopSprite;
            audioSource.Play();
        }
        else
        {
            player.Pause();
            button.image.sprite = startSprite;
            audioSource.Pause();
        }
    }
}
