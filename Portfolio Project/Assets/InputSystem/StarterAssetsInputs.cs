using System;
using UnityEngine;
using UnityEngine.Events;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;
		public bool ability1;
		public bool ability2;
		public bool ability3;
		public bool shoot;

		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

		public UnityEvent abilityUsed = new UnityEvent();

#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}

		public void OnAbility1(InputValue value){
			Ability1Input(value.isPressed);
			abilityUsed.Invoke();
			Debug.Log("1 pressed");
		}
		public void OnAbility2(InputValue value){
			Ability2Input(value.isPressed);
			abilityUsed.Invoke();
			Debug.Log("2 pressed");
		}
		public void OnAbility3(InputValue value){
			Ability3Input(value.isPressed);
			abilityUsed.Invoke();
			Debug.Log("3 pressed");
		}

		public void OnShoot(InputValue value){
			ShootInput(value.isPressed);
		}

       
#endif

		 private void ShootInput(bool newShootState)
        {
            shoot = newShootState;
        }

        public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}

		public void Ability1Input(bool newAbility1State)
		{
			ability1 = newAbility1State;
		}
		public void Ability2Input(bool newAbility2State)
		{
			ability2 = newAbility2State;
		}
		public void Ability3Input(bool newAbility3State)
		{
			ability3 = newAbility3State;
		}
		
		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}
	}
	
}