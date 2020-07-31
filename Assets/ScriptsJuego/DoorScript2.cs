using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript2 : MonoBehaviour
{
   
    public bool open=false;
   
 

    public void OpenDoor()
    {
        open = true;
    }
    void Update()
    {/*
        if (inTrigger)
        {
            if (close)
            {
                if (hasKey)
                {
                    
                    {
                        open = true;
                        close = false;
                    }
                }
            }
            else
            {
                
                {
                    close = true;
                    open = false;
                }
            }
        }
        */
       
            if (open)
            {
                var newRot = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0.0f, 90.0f, 0.0f), Time.deltaTime * 200);
                transform.rotation = newRot;
            }
         
    }

     
}
