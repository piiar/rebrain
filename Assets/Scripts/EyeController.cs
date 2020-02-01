using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EyeController : MonoBehaviour
{

    public enum EyeStates { Normal, LazyEye, Shrunk, Dilated }
    public GameObject eye;
    public GameObject pupil;
    public EyeStates eyeState = EyeStates.Normal;
    Tweener eyeTween;
    Tweener pupilTween;
    private float randomEyePosDiff = 0.25f;
    private float currentDilation = 1f;

    void Start()
    {
        Vector3 targetPos = getRandomTargetPosition ();
        eyeTween = eye.transform.DOMove(targetPos, 1f, false).OnComplete(posCompleteFunction);

        Vector3 targetScale = getRandomTargetScale ();
        pupilTween = pupil.transform.DOScale(targetScale, 1f).OnComplete(scaleCompleteFunction);
    }

    void posCompleteFunction () {
        Vector3 targetPos = getRandomTargetPosition ();
        eyeTween = eye.transform.DOMove(targetPos, 1f, false).OnComplete(posCompleteFunction);
    }

    void scaleCompleteFunction () {
        Vector3 targetPos = getRandomTargetPosition ();
        pupilTween = eye.transform.DOMove(targetPos, 1f, false).OnComplete(scaleCompleteFunction);
    }

    Vector3 getRandomTargetPosition () {
        return transform.localPosition + new Vector3 (Random.Range(-randomEyePosDiff, randomEyePosDiff), Random.Range(-randomEyePosDiff, randomEyePosDiff), 0);
    }

    Vector3 getRandomTargetScale () {
        currentDilation = Random.Range(1f, 10f);
        return new Vector3 (currentDilation, currentDilation, 0);
    }
}
