using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UniRx;

public class LogoScene : MonoBehaviour
{
    [SerializeField] private float fadeTime = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        Observable.Timer(TimeSpan.FromSeconds(fadeTime)).Subscribe(_ => SceneManager.LoadScene(GameConfig.SceneName.Title));
    }
}