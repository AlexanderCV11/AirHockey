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
    private bool selected;

    private void Awake()
    {
        scale = transform.localScale;
    }

    private void Update()
    {
        if (selected && transform.localScale.magnitude >= 1.2f)
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
            selected = true;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        selected = false;
    }

    public void FireButton()
    {
        if (GM.playerCash >= 100)
        {
            GM.refPlayer.FirePower();
            GM.playerCash -= 100;
        }
    }

    public void IceButton()
    {
        if (GM.playerCash >= 200)
        {
            GM.refPlayer.IcePower();
            GM.playerCash -= 200;
        }
    }

    public void RockButton()
    {
        if (GM.playerCash >= 300)
        {
            GM.rock.SetActive(true);
            GM.playerCash -= 300;
        }
    }
}
