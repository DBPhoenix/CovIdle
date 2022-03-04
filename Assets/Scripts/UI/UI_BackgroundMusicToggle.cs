using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_BackgroundMusicToggle : MonoBehaviour
{
    private void Start()
    {
        Toggle toggle = GetComponent<Toggle>();

        toggle.isOn = AudioManager.Instance.BackgroundMusicActive;

        toggle.onValueChanged.AddListener((value) => AudioManager.Instance.BackgroundMusicActive = value);
    }
}
