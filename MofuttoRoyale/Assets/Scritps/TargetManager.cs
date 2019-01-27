using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetManager : MonoBehaviour
{
    [SerializeField] private HouseInfo target;
    public HouseInfo TargetInfo
    {
        get { return target; }
        set { target = value; }
    }

    [SerializeField] private Image hint1Popup;
    [SerializeField] private Image hint2Popup;

    [SerializeField] private Sprite roofGreen;
    [SerializeField] private Sprite roofRed;
    [SerializeField] private Sprite roofBlue;
    [SerializeField] private Sprite roofYellow;
    [SerializeField] private Sprite window;
    [SerializeField] private Sprite chimney;

    // Start is called before the first frame update
    private void Start()
    {
     
    }

public void ShowHint()
    {
        hint1Popup.gameObject.SetActive(true);

        switch (target.RoofColor)
        {
            case ERoofColor.Red:
                hint1Popup.sprite = roofRed;
                break;
            case ERoofColor.Yellow:
                hint1Popup.sprite = roofYellow;
                break;
            case ERoofColor.Green:
                hint1Popup.sprite = roofGreen;
                break;
            case ERoofColor.Blue:
                hint1Popup.sprite = roofBlue;
                break;
        }

        hint2Popup.gameObject.SetActive(true);

        if(target.ChimneyExists)
        {
            hint2Popup.sprite = chimney;
        }
        else if(target.WindowExists)
        {
            hint2Popup.sprite = window;
        }
    }
}
