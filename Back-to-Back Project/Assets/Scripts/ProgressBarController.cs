using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ProgressBarController : MonoBehaviour
{
    public Slider slider;
    private VideoPlayer player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            slider.value = (float)player.time;

            if(slider.maxValue != (float)player.length)
            {
                slider.maxValue = (float)player.length;
            }
        }
        
    }


}
