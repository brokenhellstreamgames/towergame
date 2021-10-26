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

    public IEnumerator Run()
    {
        proActivePointTween = DOTween
            .To(g => ProActivePointUI.fillAmount = g, 0, 1, Entity.CurrentSpeed / 100f).SetSpeedBased();
        // proActivePointTween = ProActivePointUI.DOFillAmount(1, Entity.CurrentSpeed * Time.deltaTime).SetSpeedBased();
        proActivePointTween.SetLoops(GameManager.Instance.MaxProActivePoints - Entity.ProActivePoint);
        proActivePointTween.OnStepComplete(() =>
        {
            Entity.ProActivePoint++;
            ProActivePointText.text = Entity.ProActivePoint.ToString();
        });
        proActivePointTween.Play();

        yield return proActivePointTween.WaitForCompletion();
    }

    public void SetPointText(int point)
    {
        ProActivePointText.text = point.ToString();
    }
}