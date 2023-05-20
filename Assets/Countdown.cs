using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Countdown : MonoBehaviour
{
    [SerializeField] int duration;
    public UnityEvent OnStarted = new UnityEvent();
    public UnityEvent OnCountdownEnd = new UnityEvent();
    public UnityEvent<int> OnCount = new UnityEvent<int>();

    bool isCounting;
    Sequence seq;

    private void Start()
    {
        OnStarted.Invoke();
        StartCountdown();
    }

    // countdown using coroutine
    public void StartCountdown()
    {
        if (isCounting == true)
        {
            StopAllCoroutines();
        }

        StartCoroutine(CountCoroutine());
    }

    private IEnumerator CountCoroutine()
    {
        isCounting = true;
        for (int i = duration; i >= 0; i--)
        {
            OnCount.Invoke(i);
            yield return new WaitForSecondsRealtime(1);
        }
        OnCountdownEnd.Invoke();
        isCounting = false;
    }

    // countdown using do tween
    // public void StartCountdown()
    // {
    //     if (isCounting)
    //     {
    //         return;
    //     }
    //     else
    //     {
    //         isCounting = true;
    //     }
    //     seq = DOTween.Sequence();

    //     OnCount.Invoke(duration);
    //     for (int i = duration - 1; i >= 0; i--)
    //     {
    //         var count = i;
    //         seq.Append(transform
    //             .DOMove(this.transform.position, 1)
    //             .SetUpdate(true)
    //             .OnComplete(() => OnCount.Invoke(count)));
    //     }
    //     seq.Append(transform
    //         .DOMove(this.transform.position, 1))
    //         .SetUpdate(true)
    //         .OnComplete(() =>
    //         {
    //             isCounting = false;
    //             OnCountdownEnd.Invoke();
    //         });
    // }
}
