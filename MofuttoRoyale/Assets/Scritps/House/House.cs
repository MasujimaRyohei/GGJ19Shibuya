using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UniRx;
using UniRx.Triggers;

public class House : MonoBehaviour
{
    [SerializeField] private HouseInfo info;
    // Start is called before the first frame update
    private void Start()
    {
        info = new HouseInfo();
        this.OnCollisionEnterAsObservable().Where(obj => obj.transform.tag == GameConfig.Tags.Player).Subscribe(_ => SceneManager.LoadScene(GameConfig.SceneName.Title));
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
