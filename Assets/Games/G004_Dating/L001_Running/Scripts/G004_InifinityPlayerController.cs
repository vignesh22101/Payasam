using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G004_InifinityPlayerController : MonoBehaviour
{
    CharacterController controller;
    [SerializeField]
    float speed = 5.0f;

    bool inTransition;

    [SerializeField]
    float transitionSpeed;
    enum PlayerPosition
    {
        CENTER,
        LEFT,
        RIGHT
    }
    PlayerPosition playerCurrentPosition = PlayerPosition.CENTER;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        //controller.Move((Vector3.forward * speed) * Time.deltaTime);
    }
    public void MovePlayer(bool isRight)
    {
        if (isRight)
        {
            if (playerCurrentPosition != PlayerPosition.RIGHT)
            {
                if (playerCurrentPosition == PlayerPosition.CENTER)
                {
                    SetPlayerPosition(PlayerPosition.RIGHT);
                }
                else
                {
                    SetPlayerPosition(PlayerPosition.CENTER);
                }
            }
        }
        else
        {
            if (playerCurrentPosition != PlayerPosition.LEFT)
            {
                if (playerCurrentPosition == PlayerPosition.CENTER)
                {
                    SetPlayerPosition(PlayerPosition.LEFT);
                }
                else
                {
                    SetPlayerPosition(PlayerPosition.CENTER);
                }
            }
        }
    }
    void SetPlayerPosition(PlayerPosition playerPosition)
    {
        switch (playerPosition)
        {
            case PlayerPosition.LEFT:
                transform.DOMoveX(-1.5f, transitionSpeed);
                playerCurrentPosition = PlayerPosition.LEFT;
                break;
            case PlayerPosition.RIGHT:
                transform.DOMoveX(1.5f, transitionSpeed);
                playerCurrentPosition = PlayerPosition.RIGHT;
                break;
            case PlayerPosition.CENTER:
                transform.DOMoveX(0f, transitionSpeed);
                playerCurrentPosition = PlayerPosition.CENTER;
                break;
        }

    }
}
