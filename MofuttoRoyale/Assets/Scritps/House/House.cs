using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UniRx;
using UniRx.Triggers;

public class House : MonoBehaviour
{
    [SerializeField] private ERoofShape roofShape;
    [SerializeField] private ERoofColor roofColor;
    [SerializeField] private EChimney chimney;
    [SerializeField] private EWindowShape windowShape;

    // Start is called before the first frame update
    private void Start()
    {
        this.OnCollisionEnterAsObservable().Where(obj => obj.transform.tag == GameConfig.Tags.Player).Subscribe(_ => SceneManager.LoadScene(GameConfig.SceneName.Title));
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
