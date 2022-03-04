using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Death : MonoBehaviour
{
    public static UI_Death Instance;

    AudioSource _audio;
    TextMeshProUGUI _text;
    IEnumerator<string> _mem;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        _audio = GetComponent<AudioSource>();
        _text = GetComponentInChildren<TextMeshProUGUI>();

        Hide();
    }

    public void Display(IEnumerable<string> list)
    {
        _mem = list.GetEnumerator();

        transform.parent.gameObject.SetActive(true);

        Continue();
    }

    public void Continue()
    {
        CancelInvoke();

        if (_mem.MoveNext())
        {
            SetText(_mem.Current);

            _audio.Play();

            Invoke("StopAudio", 1f);
        }
        else
        {
            Hide();
        }
    }

    private void Hide()
    {
        transform.parent.gameObject.SetActive(false);
    }

    private void SetText(string text)
    {
        _text.text = text;
    }

    private void StopAudio()
    {
        _audio.Stop();
    }
}
