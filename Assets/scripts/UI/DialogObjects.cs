using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DialogData/DialogObjects")]
public class DialogObjects : ScriptableObject
{
    [SerializeField] [TextArea] private string[] dialog;

    public string[] DialogLines => dialog;
}
