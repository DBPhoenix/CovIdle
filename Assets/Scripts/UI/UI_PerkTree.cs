using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_PerkTree : MonoBehaviour
{
    public static UI_PerkTree Instance;

    private UI_Text _mutationPoints;

    bool once;

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
        if (!once)
        {
            once = true;

            UI_Death.Instance.Display(new string[] {
                "This is Covid-19's possible mutations. All of these perks benefit Covid-19 in different unique ways.",
                "The perktree is divided in 4 sections. Spreading Covid-19, lowering immunity, killing humanity and unlocking buildings.",
                "The upper left section helps spreading Covid-19. The upper right section helps against the population passively growing immune.",
                "The lower left section increases the deadliness of Covid-19. The lower right section unlocks multiple new and exciting upgrades allowing you to utilize deaths.",
                "You can always mouse over the perks at a later time to get a detailed description of the perk, and if you're stuck there's a button in the upper left corner to get you back.",
                "Now try clicking on the center perk!"
            });
        }

        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
