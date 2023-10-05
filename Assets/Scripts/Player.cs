using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController characterController;
    private Vector3 moveDirection;
    private const string IS_CACTUS = "Cactus";
    private SoundEffectPlayer soundEffectPlayer;

    [SerializeField] private float gravity = 9.81f * 2f;
    [SerializeField] private float jumpForce = 8f;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        soundEffectPlayer = FindObjectOfType<SoundEffectPlayer>();
    }

    private void OnEnable()
    {
        moveDirection = Vector3.zero;
    }

    private void Update()
    {
        moveDirection += Vector3.down * gravity * Time.deltaTime;

        if (characterController.isGrounded) 
        {
            moveDirection = Vector3.down;

            if (Input.GetButton("Jump"))
            {
                soundEffectPlayer.JumpSfx();
                moveDirection = Vector3.up * jumpForce;
            }
        }

        characterController.Move(moveDirection * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(IS_CACTUS))
        {
            soundEffectPlayer.DeathSfx();
            GameManager.Instance.GameOver();
        }
        
    }
}
