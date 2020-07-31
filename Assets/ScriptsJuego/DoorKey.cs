using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKey : MonoBehaviour
{
    public bool inTrigger;

    

    void OnTriggerExit(Collider other)
    {
        inTrigger = false;
    }

   

    
        
        
}
