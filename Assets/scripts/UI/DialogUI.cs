using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using TMPro;

public class DialogUI : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject dialogBox;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialogObjects testDialog;

    private TypeDialogEffect typeDialogEffect;
    private bool isClicked = false;

    private void Start()
    {
        typeDialogEffect = GetComponent<TypeDialogEffect>();
        CloseDialogBox();
        ShowDialog(testDialog);
    }

    public void ShowDialog(DialogObjects dialogObjects)
    {
        dialogBox.SetActive(true);
        StartCoroutine(StepThroughDialog(dialogObjects));
    }

    private IEnumerator StepThroughDialog(DialogObjects dialogObjects)
    {
        foreach (string dialog in dialogObjects.Dialog)
        {
            yield return typeDialogEffect.Run(dialog, textLabel);
            yield return new WaitUntil(() => isClicked);
            isClicked = false;
        }

        CloseDialogBox();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerPress == dialogBox)
        {
            isClicked = true;
        }
    }

    public void CloseDialogBox()
    {
        dialogBox.SetActive(false);
        textLabel.text = string.Empty;
    }
}
