using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : BattleCharacterController
{
    private bool removeFromBattle;

    internal void RemoveFromBattle()
    {
        StartCoroutine(MoveUnderGround2());
    }

    //private IEnumerator MoveUnderGround()
    //{
    //    yield return new WaitForSeconds(2f);
    //    removeFromBattle = true;
    //    Destroy(this.gameObject, 3f);
    //}
    //protected override void Update()
    //{
    //    base.Update();
    //    if(removeFromBattle)
    //    transform.Translate(new Vector3(0, -1f * Time.deltaTime));
    //}

    protected override TargetGroup GetTargetType()
    {
        return TargetGroup.HERO;
    }

    private IEnumerator MoveUnderGround2()
    {
        if (!removeFromBattle)
        {
            yield return new WaitForSeconds(2f);
            removeFromBattle = true;
            Destroy(this.gameObject, 3f);
        }
        while (gameObject.activeSelf)
        {
            transform.Translate(new Vector3(0, -1f * Time.deltaTime));
            yield return new WaitForEndOfFrame();
        }
    }
}
