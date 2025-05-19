using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Player : MonoBehaviour
{
   public static Player Instance;
   private CharacterSO characterSO;
   
   private List<CharacterSkill> skills = new List<CharacterSkill>();
   [SerializeField] private PlayerAnimation playerAnimation = null;

   public void Awake()
   {
      if (Instance != null && Instance != this)
      {
         Destroy(this.gameObject);
         return;
      }
      Instance = this;
   }

   public void CharacterSOSwitch(CharacterSO characterSO)
   {
      this.characterSO = characterSO;
      skills = this.characterSO.skills;
      playerAnimation = characterSO.prefab.transform.GetChild(0).GetComponent<PlayerAnimation>();
   }

   public bool SkillExists(SkillType skillName)
   {
      foreach (var skill in skills)
      {
         if (skill.skillType == skillName)
         {
            return true;
         }
      }
      //show notification
      //todo
      Debug.Log("you don't have skill " + skillName);
      return false;
   }

   public PlayerAnimation GetPlayerAnimation()
   {
      Debug.Log("get player animation " + playerAnimation);
      return playerAnimation;
   }
   
   public void SetPlayerAnimation(PlayerAnimation animation)
   {
      this.playerAnimation = animation;
   }
   
}
