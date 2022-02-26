using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public sealed class ColdHeatOne : UI_Perk, IPointerClickHandler, IChoiceReceiver
{
    public string ChoiceDescription;

    bool _cold;

    public void OnChoiceChosen(bool choice)
    {
        UI_Overview.Instance.Mutations -= Cost;

        _cold = !choice;

        Purchase();

        foreach (UI_Perk perk in LeadsTo)
        {
            perk.Status = PerkStatus.Enabled;
        }

        Status = PerkStatus.Purchased;
    }

    public new void OnPointerClick(PointerEventData eventData)
    {
        if (Status == PerkStatus.Enabled && UI_Overview.Instance.Mutations > Cost)
        {
            DisplayChoice();
        }
    }

    private protected override void Purchase()
    {
        Resources.FindObjectsOfTypeAll<Temperature>()[0].Cold = _cold;
    }

    private void DisplayChoice()
    {
        UI_Choice.Instance.SetHeader(gameObject.name);
        UI_Choice.Instance.SetDescription(ChoiceDescription);
        UI_Choice.Instance.SetChoiceOne("Ice Age");
        UI_Choice.Instance.SetChoiceTwo("Global Warming");
        UI_Choice.Instance.Display();
    }
}
