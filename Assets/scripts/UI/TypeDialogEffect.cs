using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypeDialogEffect : MonoBehaviour
{
    [SerializeField] private float typeSpeed = 50f;

    public Coroutine Run(string textToType, TMP_Text textLabel)
    {
        return StartCoroutine(TypeText(textToType, textLabel));
    }

    private IEnumerator TypeText(string textToType, TMP_Text textLabel)
    {
        textLabel.text = string.Empty;

        yield return new WaitForSeconds(1f);

        float i = 0;
        int charIndex = 0;

        while (charIndex < textToType.Length)
        {
            i += Time.deltaTime * typeSpeed;
            charIndex = Mathf.FloorToInt(i);
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);

            textLabel.text = textToType.Substring(0, charIndex);

            yield return null;
        }

        textLabel.text = textToType;
    }
}
