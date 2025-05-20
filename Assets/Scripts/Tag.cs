using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tag 
{
    public const string PLAYER = "Player";
    public const string NPC = "NPC";
    public const string INTERACTABLE = "Interactable";
    public const string GROUND = "Ground";
    public const string DECORATION = "Decoration";
    
}

public static class AnimationParams
{
    public static readonly int IsWalking = Animator.StringToHash("IsWalking");
    public static readonly int Water = Animator.StringToHash("Water");
    public static readonly int Harvest = Animator.StringToHash("Harvest");
    public static readonly int Clean = Animator.StringToHash("Clean");

}