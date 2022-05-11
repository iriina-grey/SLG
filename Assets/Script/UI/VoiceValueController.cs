using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VoiceValueController : MonoBehaviour
{
    
    [SerializeField]
    Slider Slider;
    [SerializeField]
    
    GameObject panel;
    private void Update()
    {
        AudioListener.volume = Slider.value;
    }
    public void ShutPanel()
    {
        panel.SetActive(false);
    }
    
}
