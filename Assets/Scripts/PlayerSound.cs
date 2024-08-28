using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PlayerSound : MonoBehaviour
{
    public static event EventHandler PlayerStepSound;
    private Player player;
    [SerializeField] private float stepTime = 0.25f;
    [SerializeField] private float timer = 0;

    private void Start()
    {
        player = GetComponent<Player>();
    }
    private void Update()
    {
        if (player.IsWalking)
        {
            timer += Time.deltaTime;
            if (timer > stepTime)
            {
                timer = 0;
                PlayStepSound();
            }
                    
        }
    }

    private void PlayStepSound()
    {
        PlayerStepSound?.Invoke(this, EventArgs.Empty);
    }
}
