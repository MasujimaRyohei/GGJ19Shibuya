using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UniRx;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public TargetManager targetManager;
    public List<House> houses;
    public GameObject waveCutIn;
    public ScoreManager scoreManager;
    public HouseBuilder houseBuilder;

    public bool Controllable { get; private set; }

    private int defaultScore = 3;
    private int score = 3;

    // Start is called before the first frame update
    private void Start()
    {
        scoreManager.Initialize();

        houses.AddRange(houseBuilder.Build5Houses());

        for (int i = 0; i < GameConfig.HouseMax; i++)
        {
            int temp = i;
            houses[i]
                .OnTouchPlayer
                .Where(_ => targetManager.TargetInfo.ChimneyExists == houses[temp].Info.ChimneyExists)
                .Where(_ => targetManager.TargetInfo.WindowExists == houses[temp].Info.WindowExists)
                .Where(_ => targetManager.TargetInfo.RoofColor == houses[temp].Info.RoofColor)
                .Subscribe(id => {
                    scoreManager.AddScore(id, score);
                    --score;
                    if(score < 0)
                    {
                        score = defaultScore;
                    }

                    
                });
        }

        targetManager.TargetInfo = houses[Random.Range(0, houses.Count - 1)].Info;


        StartCoroutine(WaveCutIn());
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
