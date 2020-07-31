using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using Taller;
using System;

namespace Taller
{
    public class UIChangeText : MonoBehaviour
    {
        TextMeshProUGUI text;
        public string EventName;
       
        
        // Start is called before the first frame update

        private void Awake()
        {
            text = GetComponent<TextMeshProUGUI>();
            if(text==null)
            {
                text = GetComponentInChildren<TextMeshProUGUI>(true); 
            }
        }
        void Start()
        {
          

            EventManager.AddEvent<string> (EventName, ChangeText);
            
        }

        void ChangeText(string newText)
        {
            if (text == null) return;
            text.SetText(newText);

        }
       
    }
}

