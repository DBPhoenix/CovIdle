using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_PerkTree : MonoBehaviour
{
    public static UI_PerkTree Instance;

    private UI_Text _mutationPoints;

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

        _mutationPoints = transform.Find("Mutation Points").GetComponent<UI_Text>();

        gameObject.SetActive(false);
    }

    private void Update()
    {
        _mutationPoints.SetValue(UI_Overview.Instance.Mutations);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Close();
        }
    }

    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
