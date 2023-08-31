using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePadController : Singleton<GamePadController>
{
    public bool IsOnMobile;
    bool moveLeft;
    bool moveRight;

    public bool MoveLeft { get => moveLeft;}
    public bool MoveRight { get => moveRight;}

    public override void Awake()
    {
        MakeSingleton(false);
    }
    private void Update()
    {
        if (!IsOnMobile) PcInputHandler();
    }
    void PcInputHandler()
    {
        moveLeft = Input.GetAxisRaw("Horizontal") == -1;
        moveRight = Input.GetAxisRaw("Horizontal") == 1;
    }
}
