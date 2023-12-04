using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class PowerUps : Selectable, IPointerDownHandler
{
    private Vector3 scale;
    private BaseEventData buttonPowerUp;

    protected override void Start()
    {
        scale = transform.localScale;
    }

    private void Update()
    {
        if (IsHighlighted())
        {
            transform.localScale = Vector3.Lerp(transform.localScale, scale * 1.2f, 5f *Time.deltaTime);
        }
        else 
        {
            transform.localScale = Vector3.Lerp(transform.localScale, scale, 3f * Time.deltaTime);
        }
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("gusa");
    }


}
