using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(fileName = "Rotate Animation", menuName = "ScriptableObjects/Animation/Rotate Animation")]
public class RotateAnimation : BaseAnimation
{
    public override void Animate(Transform visual)
    {
        base.Animate(visual);

        var seq = DOTween.Sequence();

        seq.Append(visual.DOLocalRotate(new Vector3(visual.eulerAngles.x, 180, visual.eulerAngles.z), 0.5f));
        seq.Append(visual.DOLocalRotate(new Vector3(visual.eulerAngles.x, 360, visual.eulerAngles.z), 0.5f));
        seq.SetLoops(-1);
    }
}
