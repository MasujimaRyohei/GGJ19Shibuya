using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UniRx;
using UniRx.Triggers;

public class House : MonoBehaviour
{
    [SerializeField] private HouseInfo info;
    public HouseInfo Info { get { return info; } }
    private Subject<int> onTouchPlayer = new Subject<int>();
    public IObservable<int> OnTouchPlayer { get { return onTouchPlayer; } }

    public void Initialize(HouseInfo info)
    {
        this.info = info;

        this.OnCollisionEnterAsObservable()
            .Where(obj => obj.transform.tag == GameConfig.Tags.Player)
            .Subscribe(obj =>
            {
                onTouchPlayer.OnNext(obj.transform.GetComponent<PlayerCore>().PlayerID);
                Destroy(obj.gameObject);
            });
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
