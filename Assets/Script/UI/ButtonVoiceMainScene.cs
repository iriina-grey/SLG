using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonVoiceMainScene : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;

    public void ClickVoice()
    {
        audioSource.Play();
    }
}
