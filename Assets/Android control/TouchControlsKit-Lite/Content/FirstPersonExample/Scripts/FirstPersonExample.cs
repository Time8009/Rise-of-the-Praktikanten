using UnityEngine;
using TouchControlsKit;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;

namespace Examples
{

    public class FirstPersonExample : MonoBehaviour
    {
        bool binded;
        Transform myTransform, cameraTransform;
        CharacterController controller;
        float rotation;
        bool jump, prevGrounded, isPorjectileCube;
        float weapReadyTime;
        bool weapReady = true;
        private Camera cam;
        [SerializeField]
        private float distance = 3f;
        [SerializeField]
        LayerMask mask;
        private PlayerUI PlayerUI;
        private StarterAssetsInputs inputManager;
        public static float maxSprint = 100f;
        public static float Sprint = maxSprint;

        [SerializeField]
        public float sprintMalus = 1f;
        public SprintBar SprintBar;

        public bool RunIsRunning = false;
        public bool NotRunIsRunning = false;
        public bool shiftIsPressed = false;



        private void Start()
        {
            cam = Camera.main;
            PlayerUI = GetComponent<PlayerUI>();
            inputManager = GetComponent<StarterAssetsInputs>();
        }
        // Awake
        void Awake()
        {
            myTransform = transform;
            cameraTransform = Camera.main.transform;
            controller = GetComponent<CharacterController>();
        }

        // Update
        void Update()
        {

            if (Input.GetKey(KeyCode.LeftShift))
            {
                shiftIsPressed = true;
                StartCoroutine(Run());
            }
            else
            {
                shiftIsPressed = false;
                StartCoroutine(NotRun());
            }


            if (weapReady == false)
            {
                weapReadyTime += Time.deltaTime;
                if (weapReadyTime > .15f)
                {
                    weapReady = true;
                    weapReadyTime = 0f;
                }
            }

            PlayerUI.UpdateText(string.Empty);
            Ray ray = new Ray(cam.transform.position, cam.transform.forward);
            Debug.DrawRay(ray.origin, ray.direction * distance);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, distance, mask))
            {
                if (hitInfo.collider.GetComponent<Interactable>() != null)
                {
                    Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                    PlayerUI.UpdateText(interactable.promptMessage);
                    if (TCKInput.GetAction("EBtn", EActionEvent.Down))
                    {
                        interactable.BaseInteract();
                    }

                }
            }
            Vector2 look = TCKInput.GetAxis("Touchpad");
            PlayerRotation(look.x, look.y);


        }

        // FixedUpdate
        void FixedUpdate()
        {
            /*float moveX = TCKInput.GetAxis( "Joystick", EAxisType.Horizontal );
            float moveY = TCKInput.GetAxis( "Joystick", EAxisType.Vertical );*/
            Vector2 move = TCKInput.GetAxis("Joystick"); // NEW func since ver 1.5.5
            PlayerMovement(move.x, move.y);
        }



        // PlayerMovement
        void PlayerMovement(float horizontal, float vertical)
        {
            bool grounded = controller.isGrounded;

            Vector3 moveDirection = myTransform.forward * vertical;
            moveDirection += myTransform.right * horizontal;

            moveDirection.y = -10f;

            if (jump)
            {
                jump = false;
                moveDirection.y = 25f;
                isPorjectileCube = !isPorjectileCube;
            }

            if (grounded)
                moveDirection *= 7f;

            controller.Move(moveDirection * Time.fixedDeltaTime);

            if (!prevGrounded && grounded)
                moveDirection.y = 0f;

            prevGrounded = grounded;
        }

        // PlayerRotation
        void PlayerRotation(float horizontal, float vertical)
        {
            myTransform.Rotate(0f, horizontal * 12f, 0f);
            rotation += vertical * 12f;
            rotation = Mathf.Clamp(rotation, -60f, 60f);
            cameraTransform.localEulerAngles = new Vector3(-rotation, cameraTransform.localEulerAngles.y, 0f);
        }

        // PlayerFiring
        void Runing()
        {

        }
        // PlayerClicked
        void PlayerClicked()
        {
            //Debug.Log( "PlayerClicked" );
        }


        public IEnumerator Run()
        {
            if (RunIsRunning)
                yield break;

            RunIsRunning = true;

            while (shiftIsPressed)
            {
                yield return new WaitForSeconds(0.1f);
                SprintScript.Sprint = Mathf.Clamp(SprintScript.Sprint - sprintMalus, 0f, maxSprint);
                SprintBar.UpdateSprintBar();
            }

            RunIsRunning = false;
        }

        public IEnumerator NotRun()
        {
            if (NotRunIsRunning)
                yield break;

            NotRunIsRunning = true;

            while (!shiftIsPressed)
            {
                yield return new WaitForSeconds(0.5f);
                SprintScript.Sprint = Mathf.Clamp(SprintScript.Sprint + sprintMalus, 0f, maxSprint);
                SprintBar.UpdateSprintBar();
            }

            NotRunIsRunning = false;
        }
    }
}
    
