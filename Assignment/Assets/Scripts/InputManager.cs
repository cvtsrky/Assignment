using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager :MonoBehaviour
{
    private PlayerController Den;

    void Start()
    {
        Den = FindObjectOfType<PlayerController>();
    }

   

    public static float MainHorizontal()
    {
        float i = 0.0f,a;
        i += Input.GetAxis("Horizontal");
        a = Mathf.Clamp(i, -1.0f, 1.0f);
        return a;
    }

    public static bool JButton()
    {
        return Input.GetButtonDown("Jump");
    }

    public void LeftArrow()
    {
       Debug.Log("ınput l arrow girdi");
        Den.Move(-1);
     
    }
    public void RightArrow()
    {       
        Debug.Log("ınput r arrow girdi");
        Den.Move(1);
        
    }
    public void UnpressedArrow()
    {
        Debug.Log("ınput u arrow girdi");
        Den.Move(0);
        
    }
    public void Jump()
    {
        Debug.Log("ınput j arrow girdi");
        Den.Jumper();
        
    }
}
