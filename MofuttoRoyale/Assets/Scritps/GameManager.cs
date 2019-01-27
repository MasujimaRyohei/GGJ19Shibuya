using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public PlayerProvider playerProvider;
    public PlayerCore[] players;
    public Image[] playerIcons;

    public Sprite[] number;

    [System.Serializable]
   public class Score
    {
      public  Image ten;
       public Image one;
    }

    public Score[] scoreUI;
    public BoolReactiveProperty Controllable = new BoolReactiveProperty(false);

    private int defaultScore = 3;
    private int score = 3;

    // Start is called before the first frame update
    private void Start()
    {
        players = playerProvider.CreatePlayer();

        for (int i = 0; i < players.Length; i++)
        {
            PlayerCore player = (PlayerCore)players[i];
            playerIcons[i].sprite = players[i].Icon;
        }

        Controllable.Subscribe(value =>
        {
            foreach (PlayerCore player in players)
            {
                player.IsMovable = value;
            }
        });

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


        for (int i = 0; i < players.Length; i++)
        {
            scoreManager.PlayerScores[i].Subscribe(score =>
            {
                int ten = score / 10;
                int one = score % 10;

                scoreUI[i].ten.sprite = number[ten];
                scoreUI[i].one.sprite = number[one];

            });
        }


        StartCoroutine(WaveCutIn());
    }

    private IEnumerator WaveCutIn()
    {
        Controllable.Value = false;

        float cutInTime = 1.0f;
        waveCutIn.transform.localPosition = new Vector3(-700, 0, 0);
        waveCutIn.transform.DOLocalMove(new Vector3(0, 0, 0), cutInTime);
        yield return new WaitForSeconds(2.0f);
        waveCutIn.transform.DOLocalMove(new Vector3(700, 0, 0), cutInTime);

        Controllable.Value = true;
        yield return targetManager.ShowHint();

    }
}
