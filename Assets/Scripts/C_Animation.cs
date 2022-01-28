using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Animation : MonoBehaviour
{
    public string AnimationName = "This is animation name";
    public Sprite[] Sprites;
    SpriteRenderer sprite;
    public float TimePerFrame = 0.25f;
    public int Frame = 0;
    int MaxFrame = 0;

    private void Start()
    {
        StartCoroutine(AnimationPlay());
    }

    public void StartAnimation(Sprite[] ThisSprites, string A_name)
    {
        AnimationName = A_name;
        sprite = GetComponent<SpriteRenderer>();
        Sprites = ThisSprites;
        MaxFrame = Sprites.Length;
    }

    IEnumerator AnimationPlay()
    {
        while (true)
        {
            if (Frame == MaxFrame)
            {
                Frame = 0;
            }
            else 
            if (Frame < MaxFrame)
            {
                sprite.sprite = Sprites[Frame];
                Frame++;
            }
            yield return new WaitForSeconds(TimePerFrame);
        }
    }
}
