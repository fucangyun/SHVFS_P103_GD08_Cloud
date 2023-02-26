using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//abstract members can't be used directly
//we inherit from them and implement them

public abstract class InputComponentBase : MonoBehaviour
{
    public abstract Vector2 GetInputDirection();
    public abstract Vector2 GetInputDirectionNormalized();
}

public class PlayerInputComponent : InputComponentBase
{

    private PlayerActions playerActions;

    private void Awake()
    {
        playerActions = new PlayerActions();
        playerActions.PlayerInput.Enable();
    }

    public override Vector2 GetInputDirection()
    {
        return playerActions.PlayerInput.Movement.ReadValue<Vector2>();
    }

    public override Vector2 GetInputDirectionNormalized()
    {
        return GetInputDirection().normalized;
    }

}


