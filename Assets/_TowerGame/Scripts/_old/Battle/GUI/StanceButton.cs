using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class StanceButton : MonoBehaviour, ISelectHandler
{
    private Outline outline;

    private Outline activeBtnOutline;

    public int StanceSlotID { get; set; }
    public StanceData StanceData { get; set; }
    public StanceListController ListController { get; set; }
    public HeroGroupController GroupController { get; set; }

    private void Start()
    {
        outline = GetComponent<Outline>();
    }
    public void OnSelect(BaseEventData eventData)
    {
        //throw new System.NotImplementedException();
    }

    public void OnClick()
    {
        //GroupController.SetStance(StanceData);
        outline.enabled = true;
        ListController.SetActiveButton(outline);
    }
}