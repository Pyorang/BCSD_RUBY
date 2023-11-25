using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockManRader : MonoBehaviour
{
    Vector3 Ruby_Loc;

    RectTransform rectTransform;
    RectTransform enemy;

    [SerializeField]
    private GameObject Ruby;

    private void Start()
    {
        Ruby = GameObject.FindWithTag("Player");
        enemy = transform.GetComponentInParent<RectTransform>();
        rectTransform = gameObject.GetComponent<RectTransform>();
    }

    void Update()
    {
        Ruby_Loc = Ruby.transform.position + new Vector3(0, 0.5f, 0);
        gameObject.transform.eulerAngles = new Vector3(0, 0, GetAngle(Ruby_Loc, enemy.transform.position));
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Vector2.Distance(Ruby.transform.position, enemy.transform.position) * 113);
    }

    public float GetAngle(Vector2 start, Vector2 end)
    {
        Vector2 v2 = end - start;
        return Mathf.Atan2(v2.y, v2.x) * Mathf.Rad2Deg;
    }
}
