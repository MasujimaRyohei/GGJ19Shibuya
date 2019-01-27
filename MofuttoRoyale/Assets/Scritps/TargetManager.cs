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

    [SerializeField] private GameObject hint1Popup;
    [SerializeField] private GameObject hint2Popup;

    [SerializeField] private Sprite roofGreen;
    [SerializeField] private Image roofRed;
    [SerializeField] private Image roofBlue;
    [SerializeField] private Image roofYellow;
    [SerializeField] private Image window;
    [SerializeField] private Image chimney;

    // Start is called before the first frame update
    private void Start()
    {
        Instantiate(roofGreen, hint1Popup.transform);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
