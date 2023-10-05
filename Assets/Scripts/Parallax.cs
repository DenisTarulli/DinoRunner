using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private bool scrollLeft;
    [SerializeField] private float spriteResetValue;
    [SerializeField] private float spriteResetPosition;

    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();        
        if (scrollLeft) moveSpeed = -moveSpeed;
    }

    private void Scroll()
    {
        float delta = moveSpeed * Time.deltaTime * gameManager.gameSpeed / 8f;
        transform.position += new Vector3(delta, 0f, 0f);
    }

    private void CheckReset()
    {
        if (transform.position.x < spriteResetValue)
            transform.position = new Vector3(spriteResetPosition, transform.position.y, transform.position.z);
    }

    void Update()
    {
        Scroll();
        CheckReset();
    }
}
