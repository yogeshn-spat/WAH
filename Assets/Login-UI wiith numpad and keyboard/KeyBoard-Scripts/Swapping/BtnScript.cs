using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnScript : MonoBehaviour
{
    private GameObject button1, button2;
    private Vector3 position1, position2;
    int clickedCount = 0;

    public void FixedUpdate()
    {
        if (clickedCount == 2)
        {
            button1.transform.position = Vector3.Lerp(button1.transform.position, position2, 10f * Time.deltaTime);
            button2.transform.position = Vector3.Lerp(button2.transform.position, position1, 10f * Time.deltaTime);

            Invoke("First_init",.5f);
        }
    }

    public void First_init()
    {
        
        clickedCount = 0;
    }
    public void forBtn(GameObject btn)
    {
        if (clickedCount==0)
        {
            
            button1 = btn;
            position1 = btn.transform.position;
           
            clickedCount++;
            
        }
        else if(clickedCount == 1)
        {
            button2 = btn;
            position2 = btn.transform.position;
           
            clickedCount++;

        }
    }
}
