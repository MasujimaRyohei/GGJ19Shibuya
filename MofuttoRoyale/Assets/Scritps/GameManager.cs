using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UniRx;

public class GameManager : MonoBehaviour
{
    public TargetManager targetManager;
    public List<House> houses;
    public GameObject waveCutIn;
    public ScoreManager scoreManager;

    public bool Controllable { get; private set; }

    // Start is called before the first frame update
    private void Start()
    {
        for (int i = 0; i < houses.Count; i++)
        {
            houses[i].Initialize();

            int temp = i;
            houses[i]
                .OnTouchPlayer
                .Where(_ => targetManager.TargetInfo.ChimneyExists == houses[temp].Info.ChimneyExists)
                .Subscribe(id => scoreManager.AddScore(id, 10));
        }

        targetManager.TargetInfo = houses[Random.Range(0, houses.Count - 1)].Info;


        StartCoroutine(WaveCutIn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator WaveCutIn()
    {
        Controllable = false;

        float cutInTime = 1.0f;
        waveCutIn.transform.localPosition = new Vector3(-500, 0, 0);
        waveCutIn.transform.DOLocalMove(new Vector3(0, 0, 0), cutInTime);
        yield return new WaitForSeconds(2.0f);
        waveCutIn.transform.DOLocalMove(new Vector3(500, 0, 0), cutInTime);

        Controllable = true;

    }
}
