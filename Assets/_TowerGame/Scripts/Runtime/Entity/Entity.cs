using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    protected bool _alive;

    #region Base Statistics

    [SerializeField]
    protected int _healthPoint;

    [SerializeField]
    protected int _physicalAttack;

    [SerializeField]
    protected int _magicalAttack;

    [SerializeField]
    protected int _physicalDefense;

    [SerializeField]
    protected int _magicalDefense;

    [SerializeField]
    protected int _speed;

    [SerializeField]
    protected int _proActivePointMax;

    #endregion

    #region Current Statistics

    public int CurrentHealPoint;// { get; protected set; }


    public int CurrentPhysicalAttack;// { get; protected set; }


    public int CurrentMagicalAttack;// { get; protected set; }


    public int CurrentPhysicalDefense;// { get; protected set; }


    public int CurrentMagicalDefense;// { get; protected set; }


    public int CurrentSpeed;// { get; protected set; }

    #endregion

    public int ProActivePoint;

    public EntityActivePoint ProActivePointBehaviour;

    public TargetManager TargetManager;

    // Pour le prototypage, j'ai fais un BehaviorTreeV2 et un BehaviorTreeItemV2 pour gérer + d'abilités + facilement, ça reste une proposition
    // que j'ai séparé dans son propre dossier (aussi pour pouvoir consulter le code initiale et m'assurer que je ne dévie pas trop
    // de l'idée initiale, néanmoins si ça plait pas, j'ai laisser l'ancien BehaviorTree pour y retourner à tout moment.
    // J'ai aussi crée une class StatusEffect qui fonctionne de manière similaire a la classe ability ou modifier, dont
    // chaque entités en contient une dictionnaire, en plus cette liste est directement modifié par les abilités
    // (pour check les duplicas de status effects ou pour les stacks sans pour autant changer la taille de la liste).
    public BehaviorTreeV2 BehaviorTree;
    public Coroutine FightCoroutine;

    public Dictionary<string, StatusEffect> StatusEffects = new Dictionary<string, StatusEffect>();

    private void Awake()
    {
        //BehaviorTree = new BehaviorTreeV2(this);
        BehaviorTree.items.ForEach(i => i.Initialize());
        CurrentHealPoint = _healthPoint;
        CurrentPhysicalAttack = _physicalAttack;
        CurrentMagicalAttack = _magicalAttack;
        CurrentPhysicalDefense = _physicalDefense;
        CurrentMagicalDefense = _magicalDefense;
        CurrentSpeed = _speed;

        _alive = true;
    }

    public bool IsAlive()
    {
        return _alive;
    }

    public void TakeDamage(Entity from, int damage, AbilityType type)
    {
        //Debug.Log($"{name} Receive damage from {from}");
        int entityDefense = type == AbilityType.Physic ? CurrentPhysicalDefense : CurrentMagicalDefense;
        CurrentHealPoint = CurrentHealPoint - damage * (entityDefense/10) < 0 ? 0 : CurrentHealPoint - damage * (entityDefense/10);
        if (CurrentHealPoint == 0)
        {
            _alive = false;
            gameObject.SetActive(false);
        }
    }

    // J'ai fait une rapide surcharge de TakeDamage pour pas me faire chier avec les dégâts des DOT
    public void TakeDamage(Entity from, float _damage, AbilityType type)
    {
        //Debug.Log($"{name} Receive damage from {from}");
        int damage = Mathf.RoundToInt(_damage);
        int entityDefense = type == AbilityType.Physic ? CurrentPhysicalDefense : CurrentMagicalDefense;
        CurrentHealPoint = CurrentHealPoint - damage * (entityDefense / 10) < 0 ? 0 : CurrentHealPoint - damage * (entityDefense / 10);
        if (CurrentHealPoint == 0)
        {
            _alive = false;
            gameObject.SetActive(false);
        }
    }

    // Ability.run et TargetPreference spécifient aussi l'entité d'origine pour AbilityV2
    public void PerformAttack(AbilityInstance ability, ModifierV2 modifier)
    {
        //Debug.Log($"{name} perform attack {ability.Name}");
        modifier.ModifyAbility(ability);
        ability.TargetPreference.ComputeEntities(ability.NumberOfTargets, this);
        ability.Run(ability.TargetPreference.GetEntities(), this, TargetManager);
    }

    public void StartFight()
    {
        FightCoroutine = StartCoroutine(Loop());
    }

    public void StopFight()
    {
        StopCoroutine(FightCoroutine);
    }

    public IEnumerator Loop()
    {
        while (true)
        {
            if (ProActivePoint < _proActivePointMax)
            {
                yield return ProActivePointBehaviour.Run();
            }

            while (ProActivePoint > 0)
            {
                Debug.Log(gameObject.name);
                BehaviorTreeItemV2 behaviorTreeItem = BehaviorTree.GetTreeItem(this);
                PerformAttack(behaviorTreeItem.Ability, behaviorTreeItem.Modifier);
                ProActivePoint -= behaviorTreeItem.Ability.Cost;
                ProActivePointBehaviour.SetPointText(ProActivePoint);
                behaviorTreeItem.Disable();
                //TargetManager.Launch(behaviorTreeItem.Modifier.GetEntities());
                yield return new WaitForSeconds(10 / (CurrentSpeed * Time.deltaTime));
                //TargetManager.Erase();
            }

            yield return new WaitForEndOfFrame();
        }
    }

    public int GetProActiveMaxPoints()
    {
        return _proActivePointMax;
    }
}