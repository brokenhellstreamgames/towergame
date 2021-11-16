using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    public List<Character> Characters;
    public List<Enemy> Enemies;
    
    private IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        
        Characters.ForEach(c => c.StartFight());
        Enemies.ForEach(e => e.StartFight());

        while (Characters.Count(c => c.IsAlive()) != 0 && Enemies.Count(e => e.IsAlive()) != 0)
        {
            yield return new WaitForEndOfFrame();
        }
        
        Characters.ForEach(c => c.StopFight());
        Enemies.ForEach(e => e.StopFight());

        if (Characters.Count(c => c.IsAlive()) == 0)
        {
            Debug.Log("Enemies win");
        }
        else
        {
            Debug.Log("Characters win");
        }
    }
}