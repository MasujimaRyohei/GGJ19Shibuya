using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseBuilder : MonoBehaviour
{
    [SerializeField]
    private GameObject chimney;
    [SerializeField]
    private GameObject roof;
    [SerializeField]
    private GameObject houseBase;
    [SerializeField]
    private GameObject houseBaseWithWindow;

    [SerializeField]
    private Material red;
    [SerializeField]
    private Material blue;
    [SerializeField]
    private Material yellow;
    [SerializeField]
    private Material green;

    public House BuildHouse(HouseInfo info)
    {
        GameObject houseObject = new GameObject("House" + Random.Range(0, 999));
        House house = houseObject.AddComponent<House>();
        house.Initialize(info);
        if (info.ChimneyExists)
        {
            GameObject chimneyObject = Instantiate(chimney, houseObject.transform);
            chimneyObject.transform.localPosition = new Vector3(-2.6f, 15f, 0f);

        }

        GameObject houseBaseObject;
        if (info.WindowExists)
        {
            houseBaseObject = Instantiate(houseBaseWithWindow, houseObject.transform);
        }
        else
        {
            houseBaseObject =  Instantiate(houseBase, houseObject.transform);
        }
        houseBaseObject.transform.localPosition = new Vector3(0, 0, 3.2f);  
        GameObject roofObject = Instantiate(roof, houseObject.transform);

        roofObject.transform.localPosition = new Vector3(0, 11, 3);

        Material roofMaterial = null;

        switch (info.RoofColor)
        {
            case ERoofColor.Red:
                roofMaterial = red;
                break;
            case ERoofColor.Yellow:
                roofMaterial = yellow;
                break;
            case ERoofColor.Green:
                roofMaterial = green;
                break;
            case ERoofColor.Blue:
                roofMaterial = blue;
                break;
            default:
                Debug.LogError("予期せぬ屋根の色です");
                break;
        }

        roofObject.GetComponentInChildren<Renderer>().material = roofMaterial;

        houseObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);


        return house;

    }

    public House[] Build5Houses()
    {
        House[] houses = new House[5];
        Transform parent = new GameObject("Houses").transform;

        ///////////////
        House house0 = BuildHouse(HouseInfo.GetRandomHouseInfo());
        house0.transform.SetParent(parent);
        BoxCollider collider = house0.gameObject.AddComponent<BoxCollider>();
        collider.center = new Vector3(1, 6, 3);
        collider.size = new Vector3(20, 10, 10);
        house0.transform.localPosition = new Vector3(7.5f, 0, 0.2f);
        house0.transform.localRotation =  Quaternion.Euler(0, -96, 0);
        house0.tag = GameConfig.Tags.Player;

        houses[0] = house0;

        ///////////////
        House house1 = BuildHouse(HouseInfo.GetRandomHouseInfo());
        house1.transform.SetParent(parent);
        collider = house1.gameObject.AddComponent<BoxCollider>();
        collider.center = new Vector3(1, 6, 3);
        collider.size = new Vector3(20, 10, 10);
        house1.transform.localPosition = new Vector3(-7.5f, 0, 0.2f);
        house1.transform.localRotation = Quaternion.Euler(0, 96, 0);
        house1.tag = GameConfig.Tags.Player;

        houses[1] = house1;


        ///////////////
        House house2 = BuildHouse(HouseInfo.GetRandomHouseInfo());
        house2.transform.SetParent(parent);
        collider = house2.gameObject.AddComponent<BoxCollider>();
        collider.center = new Vector3(1, 6, 3);
        collider.size = new Vector3(20, 10, 10);
        house2.transform.localPosition = new Vector3(5, 0, 4.7f);
        house2.transform.localRotation = Quaternion.Euler(0, -135, 0);
        house2.tag = GameConfig.Tags.Player;

        houses[2] = house2;

        ///////////////
        House house3 = BuildHouse(HouseInfo.GetRandomHouseInfo());
        house3.transform.SetParent(parent);
        collider = house3.gameObject.AddComponent<BoxCollider>();
        collider.center = new Vector3(1, 6, 3);
        collider.size = new Vector3(20, 10, 10);
        house3.transform.localPosition = new Vector3(-5, 0, 4.7f);
        house3.transform.localRotation = Quaternion.Euler(0, 135, 0);
        house3.tag = GameConfig.Tags.Player;

        houses[3] = house3;

        ///////////////
         House house4 = BuildHouse(HouseInfo.GetRandomHouseInfo());
        house4.transform.SetParent(parent);
        collider = house4.gameObject.AddComponent<BoxCollider>();
        collider.center = new Vector3(1, 6, 3);
        collider.size = new Vector3(20, 10, 10);
        house4.transform.localPosition = new Vector3(0, 0, 7);
        house4.transform.localRotation = Quaternion.Euler(0, 180, 0);

        houses[4] = house4;

        return houses;
    }

    private void Start()
    {
    }
}