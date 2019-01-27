using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TargetManager : MonoBehaviour
{
    [SerializeField] private HouseInfo target;
    public HouseInfo TargetInfo
    {
        get { return target; }
        set { target = value; }
    }

    [SerializeField] private Image hint1PopupImage;
    [SerializeField] private Image hint2PopupImage;
    [SerializeField] private Image hint1Popup;
    [SerializeField] private Image hint2Popup;

    [SerializeField] private Sprite roofGreen;
    [SerializeField] private Sprite roofRed;
    [SerializeField] private Sprite roofBlue;
    [SerializeField] private Sprite roofYellow;
    [SerializeField] private Sprite window;
    [SerializeField] private Sprite chimney;

    [SerializeField] private GameObject hintObjects;


    // Start is called before the first frame update
    private void Start()
    {

    }

    public IEnumerator ShowHint()
    {
        hint1Popup.gameObject.SetActive(true);
        hint2Popup.gameObject.SetActive(true);

        hint1Popup.transform.localScale = Vector3.zero;
        hint2Popup.transform.localScale = Vector3.zero;

        hint1Popup.transform.DOScale(1, 3.0f);
        hint2Popup.transform.DOScale(1, 3.0f);
        yield return new WaitForSeconds(3.0f);

        hint1PopupImage.gameObject.SetActive(true);

        switch (target.RoofColor)
        {
            case ERoofColor.Red:
                hint1PopupImage.sprite = roofRed;
                break;
            case ERoofColor.Yellow:
                hint1PopupImage.sprite = roofYellow;
                break;
            case ERoofColor.Green:
                hint1PopupImage.sprite = roofGreen;
                break;
            case ERoofColor.Blue:
                hint1PopupImage.sprite = roofBlue;
                break;
        }

        hint2PopupImage.gameObject.SetActive(true);

        if (target.ChimneyExists)
        {
            hint2PopupImage.sprite = chimney;
        }
        else if (target.WindowExists)
        {
            hint2PopupImage.sprite = window;
        }
        else
        {
            hint2Popup.gameObject.SetActive(false);
        }

        yield return new WaitForSeconds(3.0f);
        hint1Popup.gameObject.SetActive(false);
        hint2Popup.gameObject.SetActive(false);

        hintObjects.transform.DOLocalMoveY(-200, 5.0f);
    }
}