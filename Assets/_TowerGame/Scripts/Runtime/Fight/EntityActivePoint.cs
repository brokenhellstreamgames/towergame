using System;
using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class EntityActivePoint : MonoBehaviour
{
    public Entity Entity;
    
    public Image ProActivePointUI;
    public TextMeshProUGUI ProActivePointText;

    private Tween proActivePointTween;

    private void Awake()
    {
        proActivePointTween = ProActivePointUI.DOFillAmount(1, Entity.CurrentSpeed * Time.deltaTime).SetSpeedBased();
    }

    public IEnumerator Run()
    {
        proActivePointTween.SetLoops(GameManager.Instance.MaxProActivePoints - Entity.ProActivePoint).Play();
        proActivePointTween.OnStepComplete(() =>
        {
            Entity.ProActivePoint++;
            ProActivePointText.text = Entity.ProActivePoint.ToString();
        });
        yield return proActivePointTween.WaitForCompletion();
    }

    public void SetPointText(int point)
    {
        ProActivePointText.text = point.ToString();
    }
}