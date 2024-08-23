using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    [SerializeField] private DialogUI dialogUI;
    [SerializeField] private DialogObjects dialogObjects;

    private bool isPlayerInRange;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            dialogUI.ShowDialog(dialogObjects);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            dialogUI.CloseDialogBox();
        }
    }
}
