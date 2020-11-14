using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingScript : MonoBehaviour
{
    public GameObject BlinkPanel;
    private IEnumerator Coroutine;

    public bool BlinkONOFF = true;
    public float PanelTime = 2.5f;//for how long the panel stays on
    private bool _blinkloop = false;

    private void FixedUpdate()
    {
        if (!_blinkloop)
        {
        _blinkloop = true;
        Blink(BlinkONOFF);
        }
    }





    void Blink(bool IsON)
    {
        if (IsON)
        {
        StartCoroutine(CastBlink());
        }
    }


    IEnumerator CastBlink()
    {
        BlinkPanel.SetActive(false);

        yield return new WaitForSeconds(10);

        BlinkPanel.SetActive(true);

        yield return new WaitForSeconds(PanelTime);

        BlinkPanel.SetActive(false);
        _blinkloop = false;
        
    }

}
