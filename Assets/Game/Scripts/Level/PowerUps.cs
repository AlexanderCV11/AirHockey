using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class PowerUps : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    /*animaciones de power ups*/
    private Vector3 scale;
    public GameManager GM;
    private bool hover;
    public bool selected;

    private void Awake()
    {
        scale = transform.localScale;
        selected = false;
    }

    private void Update()
    {
        if (hover && transform.localScale.magnitude >= 1.2f && !selected)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, scale * 1.2f, 5f * Time.deltaTime);
        }
        else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, scale, 5f * Time.deltaTime);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (gameObject.layer == 9)
        {
            hover = true;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hover = false;
    }

    public void FireButton()
    {
        if (GM.playerCash >= 100)
        {
            selected = true;
            GM.refPlayer.FirePower();
            GM.playerCash -= 100;
            GM.uiCashPoints.text = "Points: " + GM.playerCash;
        }
    }

    public void IceButton()
    {
        if (GM.playerCash >= 200)
        {
            selected = true;
            GM.refPlayer.IcePower();
            GM.playerCash -= 200;
            GM.uiCashPoints.text = "Points: " + GM.playerCash;
        }
    }

    public void RockButton()
    {
        if (GM.playerCash >= 300)
        {
            selected = true;
            GM.rock.SetActive(true);
            GM.playerCash -= 300;
            GM.uiCashPoints.text = "Points: " + GM.playerCash;
        }
    }
}
