using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel
{
    public float JumpForce { get; private set; } = 5.0f;
    public float GravityScale { get; private set; } = 2.0f;
    public bool CanJump { get; set; } = true;
}
