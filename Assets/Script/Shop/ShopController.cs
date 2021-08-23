using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopController : MonoBehaviour
{
    [SerializeField] private List<ShopCharacterController> crafterPrefabs = default;
    [SerializeField] private Transform playerHolder = default;
    private ItemLoader itemLoader = new ItemLoader();

    public ItemLoader ItemsLoader => itemLoader;
    public List<ShopCharacterController> CrafterList { get; private set; }

    private void Awake()
    {
        CrafterList = new List<ShopCharacterController>();
        if (Application.isEditor)
        {
            Scene scene;

            scene = SceneManager.GetSceneByName("ShopUI");
            if (scene.isSubScene)
                SceneManager.LoadScene("ShopUI", LoadSceneMode.Additive);

            scene = SceneManager.GetSceneByName("ShopEnvironment");
            if (scene.isSubScene)
                SceneManager.LoadScene("ShopEnvironment", LoadSceneMode.Additive);
        }
        else
        {
            SceneManager.LoadScene("BattleUIScene", LoadSceneMode.Additive);
            SceneManager.LoadScene("ShopEnvironment", LoadSceneMode.Additive);
        }
    }

    private void Start()
    {
        foreach (var item in crafterPrefabs)
        {
            CrafterList.Add(Instantiate(item, playerHolder));
        }
    }
}
