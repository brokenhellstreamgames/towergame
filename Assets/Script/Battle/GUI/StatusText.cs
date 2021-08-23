using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StatusText : MonoBehaviour
{
    private int damage;
    private string status;
    private Text textObject;

    [SerializeField] private float duration = 2f;

    private void Awake()
    {
        textObject = GetComponent<Text>();
    }

    public void ShowText(int damage)
    {
        textObject.text = damage.ToString();
        StartCoroutine(Show());
    }

    private IEnumerator Show()
    {
        textObject.CrossFadeColor(new Color(255, 255, 255, 0), duration, false, true);
        yield return new WaitForSeconds(duration);
        Destroy(this.gameObject);
    }

    private void Update()
    {
        transform.Translate(new Vector3(0, 1f * Time.deltaTime, 0));
    }
}
