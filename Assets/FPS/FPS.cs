using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FPS : MonoBehaviour
{
    public TextMeshProUGUI fpstext;

    private float poolingtime = 3f;
    private float time;
    private float framecount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        framecount++;
        if (time >= poolingtime)
        {
            int frameRate = Mathf.RoundToInt(framecount / time);
            fpstext.text = frameRate.ToString() + "FPS";

            time -= poolingtime; framecount = 0;
        }
    }
}
