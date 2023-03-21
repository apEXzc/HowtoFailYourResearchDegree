using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;


public class gif : MonoBehaviour
{
    public List<Sprite> frames;
    public float frameRate = 10; // frames per second

    private int currentFrame = 0;
    private float timer = 0;
    private Image image;
    public string name;

    void Start()
    {
        // Get the Image component
        image = GetComponent<Image>();
        string path = "gif/" + name;
        // Load all frames as sprites and store them in the frames list
        Object[] loadedFrames = Resources.LoadAll(path, typeof(Sprite));
        foreach (Object frame in loadedFrames)
        {
            frames.Add((Sprite)frame);
        }
        frames.Sort((a, b) => int.Parse(a.name).CompareTo(int.Parse(b.name)));
    }

    void Update()
    {
        // Update the frame every frameRate seconds
        timer += Time.deltaTime;
        if (timer >= 1 / frameRate)
        {
            timer = 0 ;
            currentFrame = (currentFrame + 1) % frames.Count;
            image.sprite = frames[currentFrame];
        }
    }
}
