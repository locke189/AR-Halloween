using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fader : MonoBehaviour
{
    [SerializeField] private float fadePerSecond = 0.1f;

    bool enable; 
    bool fadeOut; 
    Material material;
    Color color;
    float offsetTime;

    void Start() {
        material = GetComponent<Renderer>().material;
        enable = false; 
        fadeOut = false; 
        color = material.color;
        offsetTime = 0f;
    }
    void Update()
    {
        material = GetComponent<Renderer>().material;
        color = material.color;
        if(fadeOut && enable)
        {
            FadeOut();    
        } 
        else if (!fadeOut && enable)
        {
            FadeIn();
        }
    }

    private void FadeOut()
    {
        var delta = (color.a - (fadePerSecond * GetCurrentTime()));
        if(delta > 0) 
        {
            material.color = new Color(color.r, color.g, color.b, delta);
        }
        else 
        {
            enable = false;
        }
    }

    private void FadeIn()
    {
        var delta = (color.a + (fadePerSecond * GetCurrentTime()));
        print(delta);
        if(delta < 1) 
        {
            material.color = new Color(color.r, color.g, color.b, delta);
        }
        else 
        {
            enable = false;
        }
    }

    private float GetCurrentTime()
    {
        return Time.deltaTime - offsetTime;
    }

    public void StartFadeOut() 
    {
        enable = true; 
        fadeOut = true; 
        material.color = new Color(color.r, color.g, color.b, 1f);
        offsetTime = Time.deltaTime;
        print("this is the fader public method");
    }

    public void StartFadeIn() 
    {
        enable = true; 
        fadeOut = false; 
        offsetTime = Time.deltaTime;
        material.color = new Color(color.r, color.g, color.b, 0f);
        print("this is the fader public method");
    }
}
