using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using D2D;
using D2D.Utils;
using TMPro;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
   [SerializeField] private string interactableName;
   [SerializeField] private string interactableHint;
   [SerializeField] private float _interactDistance;
   [SerializeField] private float _outlineWidthOnHover;

   public bool isInteractable = true;

   private Outline _outline;
   private Hint _hint;
   private Transform _player;

   private bool IsReachable
   {
      get
      {
         if (_player == null)
            return true;
         
         var vectorToPlayer = _player.position - transform.position;
         return vectorToPlayer.magnitude <= _interactDistance;
      }
   }

   private void OnDrawGizmos()
   {
      if (!TryGetComponent(out Outline l))
         gameObject.AddComponent<Outline>();

      GetComponent<Outline>().OutlineWidth = 0;
   }

   private void Awake()
   {
      _outline = GetComponent<Outline>();
      _hint = FindObjectOfType<Hint>();
      _player = FindObjectOfType<Player>()?.transform;
      
      OnAwake();
   }

   protected virtual void OnAwake()
   {
      
   }
   
   void OnMouseOver()
   {
      if (!isInteractable || !IsReachable)
         return;
      
      SwitchVisuals(true);
   }

   void OnMouseExit()
   {
      if (!isInteractable)
         return;
      
      SwitchVisuals(false);
   }

   private void OnMouseDown()
   {
      if (isInteractable && IsReachable)
         Action();
   }
   
   private void SwitchVisuals(bool state)
   {
      _outline.OutlineWidth = state ? _outlineWidthOnHover : 0;

      if (state)
      {
         _hint.Show(interactableName, interactableHint);
      }
      else
      {
         _hint.Hide();
      }
   }

   private void Action()
   {
      _hint.Hide();

      OnAction();
   }

   protected abstract void OnAction();
}
