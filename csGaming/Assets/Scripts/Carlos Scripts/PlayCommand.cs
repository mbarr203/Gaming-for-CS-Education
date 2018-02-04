using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class PlayCommand : MonoBehaviour
{
    ButtonClick btnInstance;
    GameObject Player;
    public Button playButton;
   
    public Rigidbody playerRigidbody;
    public Animator anim;
    int floormask;
    float camRayLength = 100f;


    private float moveSpeed = 3f;
    private float gridSize = 1f;
    private enum Orientation
    {
        Horizontal,
        Vertical
    };
    private Orientation gridOrientation = Orientation.Horizontal;
    private bool isMoving = false;
    private bool Lock = false;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private Vector2 input;
    private float haxis;
    private float vaxis;
    private float t;

    // Use this for initialization
    void Start ()
    {
        floormask = LayerMask.GetMask("Floor");
        
        Player = GameObject.FindGameObjectWithTag("Player");
        // playerRigidbody = GetComponent<Rigidbody>();

        Button btn = playButton.GetComponent<Button>();
        btnInstance = GetComponent<ButtonClick>();

        btn.onClick.AddListener(TaskOnClick);
    }

    void Animating(float h, float v)
    {
        bool walking = (h != 0 || v != 0);

        anim.SetBool("Moving", walking);
    }

	
	void TaskOnClick()
    {
        Debug.Log("Play button pressed!");
        StartCoroutine(Execute());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!isMoving)
        {
            Animating(0,0);
            input = new Vector2(haxis, vaxis);

            if(Mathf.Abs(input.x) > Mathf.Abs(input.y))
            {
                input.y = 0;
            }
            else
            {
                input.x = 0;
            }

            if(input != Vector2.zero)
            {
                StartCoroutine(Move(transform));
            }
        }
        else
        {
            Animating(1, 0);
        }
    }

    public IEnumerator Execute()
    {
        for (int i = 0; i < btnInstance.commandList.Length; i++)
        {
            if ("moveLeft()".Equals(btnInstance.commandList[i]))
            {
                Debug.Log("moveLeft command issued.");
                haxis += -1;
                vaxis += 0;
                btnInstance.commandList[i] = "";
                yield return new WaitForSeconds(1f);
            }
            else if ("moveRight()".Equals(btnInstance.commandList[i]))
            {
                Debug.Log("moveRight command issued.");
                haxis += 1;
                vaxis += 0;
                btnInstance.commandList[i] = "";
                yield return new WaitForSeconds(1f);
            }
            else if ("moveUp()".Equals(btnInstance.commandList[i]))
            {
                Debug.Log("moveUp command issued.");
                haxis += 0;
                vaxis += 1;
                btnInstance.commandList[i] = "";
                yield return new WaitForSeconds(1f);
            }
            else if ("moveDown()".Equals(btnInstance.commandList[i]))
            {
                Debug.Log("moveDown command issued.");
                haxis += 0;
                vaxis += -1;
                btnInstance.commandList[i] = "";
                yield return new WaitForSeconds(1f);
            }
            //Animating(0, 0);
            
        }

        btnInstance.i = 0;
        yield return new WaitForFixedUpdate();
    }

    public IEnumerator Move(Transform transform)
    {
        isMoving = true;

        startPosition = Player.transform.position;
        t = 0;

        if(gridOrientation == Orientation.Horizontal)
        {
            endPosition = new Vector3(startPosition.x + System.Math.Sign(input.x) * gridSize,
                startPosition.y, startPosition.z + System.Math.Sign(input.y) * gridSize);
        }
        else
        {
            endPosition = new Vector3(startPosition.x + System.Math.Sign(input.x) * gridSize,
               startPosition.y + System.Math.Sign(input.y) * gridSize, startPosition.z);
        }

        while (t < 1f)
        {
            t += Time.deltaTime * (moveSpeed / gridSize);
            Player.transform.position = Vector3.Lerp(startPosition, endPosition, t);
            yield return null;
        }
        isMoving = false;
        Lock = false;
        haxis = 0;
        vaxis = 0;
        yield return 0;

    }

    //Work in progress
    void Turning()
    {
        // Create a ray from the mouse cursor on screen in the direction of the camera.
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Create a RaycastHit variable to store information about what was hit by the ray.
        RaycastHit floorHit;

        // Perform the raycast and if it hits something on the floor layer...
        if (Physics.Raycast(camRay, out floorHit, camRayLength, floormask))
        {
            // Create a vector from the player to the point on the floor the raycast from the mouse hit.
            Vector3 playerToMouse = floorHit.point - transform.position;

            // Ensure the vector is entirely along the floor plane.
            playerToMouse.y = 0f;

            // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            // Set the player's rotation to this new rotation.
            playerRigidbody.MoveRotation(newRotation);
        }
    }
}
