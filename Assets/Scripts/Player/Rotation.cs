using UnityEngine;
using CnControls;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class Rotation : MonoBehaviour
    {
        public float movementSpeed = 20f;

        private Transform mainCameraTransform;
        private Transform transform;
        private CharacterController characterController;

        private void OnEnable()
        {
            mainCameraTransform = Camera.main.GetComponent<Transform>();
            characterController = GetComponent<CharacterController>();
            transform = GetComponent<Transform>();
        }

        public void Update()
        {
            // Just use CnInputManager. instead of Input. and you're good to go
            var inputVector = new Vector3(CnInputManager.GetAxis("Horizontal"), CnInputManager.GetAxis("Vertical"));
            Vector3 movementVector = Vector3.zero;

            // If we have some input
            if (inputVector.sqrMagnitude > 0.00001f)
            {
                movementVector = mainCameraTransform.TransformDirection(inputVector);
                movementVector.y = 0f;
                movementVector.Normalize();
                movementVector /= movementSpeed;
                transform.Rotate(movementVector);
            }

            movementVector += Physics.gravity;
            characterController.Move(movementVector * Time.deltaTime);
        }
    }
}