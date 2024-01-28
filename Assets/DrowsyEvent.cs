// using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class DrowsyEvent : ActionEvent
{
    // [SerializeField]
    // private Camera MainCamera;

    [SerializeField]
    private Image DrowsyImage;

    private Color _alphaColor;
    private Color _clearColor;

    public float duration = 2f; // Duration of each alpha tween
    public float startAlpha = 1f; // Starting alpha value
    public float endAlpha = 0f; // Ending alpha value

    private void Awake()
    {
        _alphaColor = DrowsyImage.color;
        _clearColor = DrowsyImage.color;
        _alphaColor.a = 1f;
        _clearColor.a = 0f;
        TweenToClear();
        
    }

    private void Tween()
    {
        Camera.main.GetComponent<AmbientSounds>().drowsyEvent();
        DrowsyImage.DOColor(_alphaColor, Random.Range(0.25f, 1.5f))
            .SetEase(Ease.InOutQuad)
            .OnComplete(() => TweenToClear()); // When complete, call the PingPongAlpha method to repeat;
    }

    private void TweenToClear()
    {
        DrowsyImage.DOColor(_clearColor, Random.Range(0.75f, 1f))
            .SetEase(Ease.InOutQuad)
            .OnComplete(() => 
                {
                    var random = Random.Range(0f,1f);
                    Debug.Log(random);
                    if (random > 0.6) StartCoroutine(Wait());
                    else Tween();
                }); // When complete, call the PingPongAlpha method to repeat;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(Random.Range(2,5));
        Tween();
    }
}
