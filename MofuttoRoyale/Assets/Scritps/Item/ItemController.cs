using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField] GameObject[] items;
    [SerializeField] GameObject Stage;

    private float stageX;
    private float stageZ;

    void Start()
    {
        stageX = Stage.GetComponent<Renderer>().bounds.size.x;
        stageZ = Stage.GetComponent<Renderer>().bounds.size.z;
        Debug.Log("X:" + stageX + "Z:" + stageZ);

        StartCoroutine(CreateItems(10, 2f));
    }

    public IEnumerator CreateItems(int makeNum, float interval)
    {
        for (var i = 0; i < makeNum; i++)
        {
            yield return new WaitForSeconds(interval);
            var pos = new Vector3(Random.Range(-stageX / 2, stageX / 2), 0, Random.Range(-stageZ / 2, stageZ / 2));
            Instantiate(items[Random.Range(0, items.Length)], pos, Quaternion.identity);
        }
    }
}
