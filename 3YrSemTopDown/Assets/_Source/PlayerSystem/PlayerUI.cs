using TMPro;
using UnityEngine;

public class PlayerUI
{
    public void ShowPlayerUI(TextMeshProUGUI TMP,
                             int remainAmount,
                             char middleSymbol,
                             int maxAmount)
    {
        TMP.text = $"{remainAmount}{middleSymbol}{maxAmount}";
    }
}
