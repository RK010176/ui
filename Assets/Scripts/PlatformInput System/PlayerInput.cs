
using System;
using UnityEngine;


public class PlayerInput : MonoBehaviour, IPlayerInput
{
    private IPlatformInput PI;

    public bool FireWeapons { get; set; }
    public event Action OnFire = delegate { };

    public bool Forward { get; set; }
    public bool Backword { get; set; }
    public bool Right { get; set; }
    public bool Left { get; set; }
    public bool PanLeft { get; set; }
    public bool PanRight { get; set; }
    public bool Idle { get; set; }
    public bool Up { get; set; }
    public bool Down { get; set; }
    public bool SpaceBar { get; set; }
    public bool Akey { get; set; }
    public bool Jkey { get; set; }

    private void Start()
    {
        PI = GetComponent<IPlatformInput>();
    }

    private void Update()
    {
        Up = PI.Up();
        Down = PI.Down();
        Forward = PI.Forward();
        Backword = PI.Backword();
        Right = PI.Right();
        Left = PI.Left();
        PanRight = PI.PanRight();
        PanLeft = PI.PanLeft();
        SpaceBar = PI.SpaceBar();
        Akey = PI.Akey();
        Jkey = PI.Jkey();
        FireWeapons = PI.FireWeapons();
        if (FireWeapons)
            OnFire();
    }


}

