using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UniRx;
using UniRx.Triggers;

public class TitleScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.UpdateAsObservable().Where(_ => Input.anyKeyDown).Subscribe(_ => SceneManager.LoadScene(GameConfig.SceneName.Main));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
