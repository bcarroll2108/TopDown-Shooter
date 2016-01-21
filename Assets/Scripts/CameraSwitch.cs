using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraSwitch : MonoBehaviour
{
    public Camera[] cams;

    public GameObject UIIsPlaying;
    public GameObject UIIsPaused;


    public CanvasGroup joysticks;


    void Start()
    {
        isPlaying();
    }

   public void camMain()
    {
        cams[0].enabled = true;
        cams[1].enabled = false;
        isPlaying();
        Time.timeScale = 1;
        
    }

    public void camTop()
    {
        cams[0].enabled = false;
        cams[1].enabled = true;
        isPaused();
        Time.timeScale = 0;

    }

    void isPaused()
    {
        {
            UIIsPlaying.SetActive(false);
            UIIsPaused.SetActive(true);
            joysticks.alpha = 0f;
        }
    }

    void isPlaying()
        {
            UIIsPlaying.SetActive(true);
            UIIsPaused.SetActive(false);
        joysticks.alpha = 100f;
    } 
    }


