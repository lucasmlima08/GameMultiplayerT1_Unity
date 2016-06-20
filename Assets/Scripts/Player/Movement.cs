using UnityEngine;
using CnControls;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class Movement : MonoBehaviour
    {
		public float speed = 6.0f;
		public float jumpSpeed = 8.0F;
		public float gravity = 20.0F;

		private Vector3 moveDirection = Vector3.zero;

        public void Update()
        {
			CharacterController controller = GetComponent<CharacterController>();

			if (controller.isGrounded)
			{
				moveDirection = new Vector3(CnInputManager.GetAxis("Horizontal"), 0, CnInputManager.GetAxis("Vertical"));
				moveDirection = transform.TransformDirection(moveDirection);
				moveDirection *= speed;
				/*if (Input.GetButton("Jump"))
				{
					moveDirection.y = jumpSpeed;
				}*/
			}

			moveDirection.y -= gravity * Time.deltaTime;
			controller.Move(moveDirection * Time.deltaTime);
        }
    }
}