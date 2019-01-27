using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    [SerializeField] private HouseInfo target;
    public HouseInfo TargetInfo
    {
        get { return target; }
        set { target = value; }
    }
    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
}
