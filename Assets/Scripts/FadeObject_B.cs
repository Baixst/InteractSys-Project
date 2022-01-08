using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeObject_B : MonoBehaviour
{
    public bool fadeOut = false;
    public bool fadeIn = false;
    public float fadeSpeed;
    private Component[] sprites;

    void Update()
    {
        if (fadeOut)
        {
            float fadeAmount;

            // fade all the bars
            sprites = gameObject.GetComponentsInChildren<SpriteRenderer>();
            foreach (SpriteRenderer sprite in sprites)
            {
                Color spriteColor = sprite.color;
                fadeAmount = spriteColor.a - (fadeSpeed * Time.deltaTime);
                spriteColor = new Color(spriteColor.r, spriteColor.g, spriteColor.b, fadeAmount);
                sprite.color = spriteColor;
            }

            // fade the task text
            Color textColor = gameObject.GetComponentInChildren<Text>().color;
            fadeAmount = textColor.a - (fadeSpeed * Time.deltaTime);

            textColor = new Color(textColor.r, textColor.g, textColor.b, fadeAmount);
            gameObject.GetComponentInChildren<Text>().color = textColor;

            if (textColor.a <= 0)
            {
                fadeOut = false;
            }
        }

        if (fadeIn)
        {
            // fade all the bars
            sprites = gameObject.GetComponentsInChildren<SpriteRenderer>();
            foreach (SpriteRenderer sprite in sprites)
            {
                Color spriteColor = sprite.color;
                spriteColor = new Color(spriteColor.r, spriteColor.g, spriteColor.b, 1f);
                sprite.color = spriteColor;
            }

            // fade the task text
            Color textColor = gameObject.GetComponentInChildren<Text>().color;
            textColor = new Color(textColor.r, textColor.g, textColor.b, 1f);
            gameObject.GetComponentInChildren<Text>().color = textColor;

            fadeIn = false;
        }
    }
}
