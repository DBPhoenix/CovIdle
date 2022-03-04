using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_AudioSlider : MonoBehaviour
{
    private void Start()
    {
        Slider slider = GetComponent<Slider>();

        slider.value = AudioManager.Instance.MasterVolume;

        slider.onValueChanged.AddListener(AudioManager.Instance.SetVolume);
    }
}
