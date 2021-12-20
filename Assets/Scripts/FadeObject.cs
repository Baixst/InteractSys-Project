using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeObject : MonoBehaviour
{
    public bool fadeOut = false;
    public bool fadeIn = false;
    public float fadeSpeed;

    void Update()
    {
        if (fadeOut)
        {
            // fade the check box image
            Color imageColor = gameObject.GetComponentInChildren<Image>().color;
            float fadeAmount = imageColor.a - (fadeSpeed * Time.deltaTime);

            imageColor = new Color(imageColor.r, imageColor.g, imageColor.b, fadeAmount);
            gameObject.GetComponentInChildren<Image>().color = imageColor;

            // fade the task text
            Color textColor = gameObject.GetComponentInChildren<Text>().color;
            fadeAmount = textColor.a - (fadeSpeed * Time.deltaTime);

            textColor = new Color(textColor.r, textColor.g, textColor.b, fadeAmount);
            gameObject.GetComponentInChildren<Text>().color = textColor;

            // fade the checkbox marker
            Color checkmarkColor = gameObject.GetComponentInChildren<Toggle>().graphic.color;
            fadeAmount = checkmarkColor.a - (fadeSpeed * Time.deltaTime);

            checkmarkColor = new Color(checkmarkColor.r, checkmarkColor.g, checkmarkColor.b, fadeAmount);
            gameObject.GetComponentInChildren<Toggle>().graphic.color = checkmarkColor;

            if (imageColor.a <= 0)
            {
                fadeOut = false;
            }
        }

        if (fadeIn)
        {
            // fade in the checkbox image
            Color imageColor = gameObject.GetComponentInChildren<Image>().color;
            imageColor = new Color(imageColor.r, imageColor.g, imageColor.b, 1f);
            gameObject.GetComponentInChildren<Image>().color = imageColor; 

            // fade in the task text
            Color textColor = gameObject.GetComponentInChildren<Text>().color;
            textColor = new Color(textColor.r, textColor.g, textColor.b, 1f);
            gameObject.GetComponentInChildren<Text>().color = textColor;

            // fade in the checkbox marker
            Color checkmarkColor = gameObject.GetComponentInChildren<Toggle>().graphic.color;
            checkmarkColor = new Color(checkmarkColor.r, checkmarkColor.g, checkmarkColor.b, 1f);
            gameObject.GetComponentInChildren<Toggle>().graphic.color = checkmarkColor;

            fadeIn = false;
        }
    }
}
