using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedSprite : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private Sprite jumpSprite;
    [SerializeField] private Player player;

    private SpriteRenderer spriteRenderer;
    private int frame;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        Invoke(nameof(Animate), 0f);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void Animate()
    {
        if (!player.characterController.isGrounded)
        {
            spriteRenderer.sprite = jumpSprite;
        }
        else
        {
            frame++;

            if (frame >= sprites.Length)
                frame = 0;

            if (frame >= 0 && frame < sprites.Length)
                spriteRenderer.sprite = sprites[frame];
        }        

        Invoke(nameof(Animate), 1f / GameManager.Instance.gameSpeed);
    }   
}
