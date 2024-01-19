using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Points : MonoBehaviour
{
    public TMP_Text score;

    void Start()
    {
        score = GetComponent<TMP_Text>();
        score.text = "+100";
    }

    // Update is called once per frame
    void Update()
    {
        score.alpha = Mathf.Lerp(score.alpha, 0.0f, 10.0f * Time.deltaTime);
        Destroy(gameObject, 1.0f);
    }
}
