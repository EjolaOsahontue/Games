using UnityEngine;

public class ObstacleControl : MonoBehaviour
{
    public GameObject thePlayer; // Reference to the player GameObject
    public GameObject charModel; // Reference to the character model
    public AudioSource crashThud; // Audio source for crash sound
    public GameObject mainCam; // Reference to the main camera
    public GameObject levelControl; // Reference to the level control object

    void OnTriggerEnter(Collider other)
    {
        // Check if the collided object is the player
        if (other.gameObject == thePlayer)
        {
            // Disable the collider to prevent further triggers
            GetComponent<BoxCollider>().enabled = false;

            // Disable player movement
            PlayerMove playerMove = thePlayer.GetComponent<PlayerMove>();
            if (playerMove != null)
            {
                playerMove.enabled = false;

                // Stop coroutines if the player is jumping
                if (playerMove.isJumping)
                {
                    playerMove.StopAllCoroutines();
                }
            }
            else
            {
                Debug.LogError("PlayerMove component is missing on the player.");
            }

            // Play stumble animation
            Animator animator = charModel.GetComponent<Animator>();
            if (animator != null)
            {
                animator.Play("Stumble Backwards");
            }
            else
            {
                Debug.LogError("Animator component is missing on charModel.");
            }

            // Play crash sound
            if (crashThud != null)
            {
                crashThud.Play();
            }
            else
            {
                Debug.LogError("AudioSource 'crashThud' is not assigned.");
            }

            // Enable camera animation
            Animator cameraAnimator = mainCam.GetComponent<Animator>();
            if (cameraAnimator != null)
            {
                cameraAnimator.enabled = true;
            }
            else
            {
                Debug.LogError("Animator component is missing on mainCam.");
            }

            // Disable LevelDistance and enable EndRunSequence
            if (levelControl != null)
            {
                LevelDistance levelDistance = levelControl.GetComponent<LevelDistance>();
                EndRunSequence endRunSequence = levelControl.GetComponent<EndRunSequence>();

                if (levelDistance != null)
                {
                    levelDistance.enabled = false;
                }
                else
                {
                    Debug.LogError("LevelDistance component is missing on levelControl.");
                }

                if (endRunSequence != null)
                {
                    endRunSequence.enabled = true;
                }
                else
                {
                    Debug.LogError("EndRunSequence component is missing on levelControl.");
                }
            }
            else
            {
                Debug.LogError("Level control is not assigned.");
            }
        }
    }
}
