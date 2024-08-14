using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIcontroller : MonoBehaviour
{
    private bool isShowing = false;
    public Canvas canvasToControl;

    void Start()
    {
        canvasToControl.enabled = false;
    }

    public void ShowCanvasForSeconds(float secondsToShow)
    {
        if (!isShowing)
        {
            isShowing = true;
            canvasToControl.enabled = true;
            StartCoroutine(HideAfterSeconds(secondsToShow));
        }
    }

    private IEnumerator HideAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        canvasToControl.enabled = false;
        isShowing = false;
    }


}
