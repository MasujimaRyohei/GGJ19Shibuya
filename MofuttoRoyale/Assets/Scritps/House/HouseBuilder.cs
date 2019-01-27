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
        if (info.ChimneyExists)
        {
            GameObject chimneyObject = Instantiate(chimney, houseObject.transform);
            chimneyObject.transform.localPosition = new Vector3(-2.6f, 16f, 0f);

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

        roofObject.transform.localPosition = new Vector3(0, 12, 0);

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

    public void Build5Houses()
    {
        Transform parent = new GameObject("Houses").transform;

        ///////////////
        HouseInfo info = HouseInfo.GetRandomHouseInfo();
        House house = BuildHouse(info);
        house.transform.SetParent(parent);
        BoxCollider collider = house.gameObject.AddComponent<BoxCollider>();
        collider.center = new Vector3(1, 6, 2);
        collider.size = new Vector3(20, 10, 10);
        house.transform.localPosition = new Vector3(7.5f, 0, 0.2f);
        house.transform.localRotation =  Quaternion.Euler(0, -96, 0);
        house.tag = GameConfig.Tags.Player;

        ///////////////
        info = HouseInfo.GetRandomHouseInfo();
        house = BuildHouse(info);
        house.transform.SetParent(parent);
        collider = house.gameObject.AddComponent<BoxCollider>();
        collider.center = new Vector3(1, 6, 2);
        collider.size = new Vector3(20, 10, 10);
        house.transform.localPosition = new Vector3(-7.5f, 0, 0.2f);
        house.transform.localRotation = Quaternion.Euler(0, 96, 0);
        house.tag = GameConfig.Tags.Player;

        ///////////////
        info = HouseInfo.GetRandomHouseInfo();
        house = BuildHouse(info);
        house.transform.SetParent(parent);
        collider = house.gameObject.AddComponent<BoxCollider>();
        collider.center = new Vector3(1, 6, 2);
        collider.size = new Vector3(20, 10, 10);
        house.transform.localPosition = new Vector3(5, 0, 4.7f);
        house.transform.localRotation = Quaternion.Euler(0, -135, 0);
        house.tag = GameConfig.Tags.Player;

        ///////////////
        info = HouseInfo.GetRandomHouseInfo();
        house = BuildHouse(info);
        house.transform.SetParent(parent);
        collider = house.gameObject.AddComponent<BoxCollider>();
        collider.center = new Vector3(1, 6, 2);
        collider.size = new Vector3(20, 10, 10);
        house.transform.localPosition = new Vector3(-5, 0, 4.7f);
        house.transform.localRotation = Quaternion.Euler(0, 135, 0);
        house.tag = GameConfig.Tags.Player;

        ///////////////
        info = HouseInfo.GetRandomHouseInfo();
        house = BuildHouse(info);
        house.transform.SetParent(parent);
        collider = house.gameObject.AddComponent<BoxCollider>();
        collider.center = new Vector3(1, 6, 2);
        collider.size = new Vector3(20, 10, 10);
        house.transform.localPosition = new Vector3(0, 0, 7);
        house.transform.localRotation = Quaternion.Euler(0, 180, 0);
    }

    private void Start()
    {
        HouseInfo info = HouseInfo.GetRandomHouseInfo();
        print("color "+info.RoofColor + " : window " + info.WindowExists + " : chimney " + info.ChimneyExists);
        Build5Houses();
    }
}