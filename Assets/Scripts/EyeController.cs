using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EyeController : MonoBehaviour
{

    public enum EyeStates { Normal, LazyEye, Shrunk, Dilated }
    public GameObject rightEye;
    public GameObject leftEye;
    public GameObject rightPupil;
    public GameObject leftPupil;
    public EyeStates eyeState = EyeStates.Normal;

    Tweener eyeTweenL;
    Tweener eyeTweenR;
    Tweener pupilTweenL;
    Tweener pupilTweenR;

    private float randomEyePosDiff = 0.4f;
    private float currentDilation = 1f;

    void Start()
    {
        Vector3 targetPos = getRandomTargetPosition ();
        eyeTweenR = rightEye.transform.DOLocalMove(targetPos, 1f, false).SetLoops(-1, LoopType.Yoyo).OnComplete(posCompleteFunction);
        eyeTweenL = leftEye.transform.DOLocalMove(targetPos, 1f, false).SetLoops(-1, LoopType.Yoyo).OnComplete(posCompleteFunction);

        leftPupil.transform.localScale = Vector3.one;
        rightPupil.transform.localScale = Vector3.one;

        Vector3 targetScale = new Vector3(10f, 10, 1f);
        pupilTweenL = leftPupil.transform.DOScale(targetScale, 1f).SetLoops(-1, LoopType.Yoyo);
        pupilTweenR = rightPupil.transform.DOScale(targetScale, 1f).SetLoops(-1, LoopType.Yoyo);
    }

    void posCompleteFunction () {
        Vector3 targetPos = getRandomTargetPosition ();
        eyeTweenR.ChangeEndValue(targetPos);
        eyeTweenL.ChangeEndValue(targetPos);
    }

    // void scaleCompleteFunction () {
    //     Vector3 targetPos = getRandomTargetPosition ();
    //     pupilTweenR = rightPupil.transform.DOMove(targetPos, 2f, false).OnComplete(scaleCompleteFunction);
    //     pupilTweenL = rightPupil.transform.DOMove(targetPos, 2f, false).OnComplete(scaleCompleteFunction);
    // }

    Vector3 getRandomTargetPosition () {
        return transform.localPosition + new Vector3 (Random.Range(-randomEyePosDiff, randomEyePosDiff), Random.Range(-randomEyePosDiff, randomEyePosDiff), 0);
    }

    // Vector3 getRandomTargetScale () {
    //     currentDilation = Random.Range(5f, 15f);
    //     return new Vector3 (currentDilation, currentDilation, 0);
    // }
}
