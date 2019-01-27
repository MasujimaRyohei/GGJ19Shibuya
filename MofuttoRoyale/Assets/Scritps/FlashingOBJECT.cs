using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class FlashingOBJECT : MonoBehaviour
{
    [SerializeField] private float angularFrequency = 5f;
    private Image image;

    void Start()
    {
        float time = 0.0f;
        image = GetComponent<Image>();
        Observable.Interval(TimeSpan.FromSeconds(Time.deltaTime)).Subscribe(_ =>
          {
              time += angularFrequency * Time.deltaTime;
              var color = image.color;
              color.a = Mathf.Sin(time) * 0.5f + 0.5f;
              image.color = color;
          }).AddTo(this);
    }
}
