using System.Collections;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float leftRightSpeed = 4f;
    static public bool canMove = false;
    // Movement limits
    public float leftBoundary = -4.5f;
    public float rightBoundary = 4.5f;
    public bool isJumping = false;
    public bool comingDown = false;
    public GameObject playerObject;
    void Update()
    {
        // Move forward constantly
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        if (canMove == true)
        {
            // Move left
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
            }

            // Move right
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(Vector3.right * Time.deltaTime * leftRightSpeed);
            }

            // **Clamp Position to Stay Inside Boundaries**
            float clampedX = Mathf.Clamp(transform.position.x, leftBoundary, rightBoundary);
            transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space))
        {
            if (isJumping == false)
            {
                isJumping = true;
                playerObject.GetComponent<Animator>().Play("Jump");
                StartCoroutine(JumpSequence()); 
            }

        }
        if(isJumping == true)
        {
            if(comingDown== false)
            {
                transform.Translate(Vector3.up* Time.deltaTime * 5, Space.World); 
            }
            if (comingDown == true)
            {
                transform.Translate(Vector3.up * Time.deltaTime * -5, Space.World);
            }
        }
    }

    IEnumerator JumpSequence()
    {
        yield return new WaitForSeconds(0.55f);
        comingDown=true;
        yield return new WaitForSeconds(0.55f);
        isJumping=false;
        comingDown = false;
        playerObject.GetComponent<Animator>().Play("Fast Run");
    }
}
