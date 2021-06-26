using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float zBound;
    public GameObject projectilePrefab;

    
    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ConstraintPlayerPosition();
        ShootFood();
    }
    //moves the player based on arrow key input
    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //transform.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime);
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
    }

    // prevents the player from leaving top or bottom of the screen
    void ConstraintPlayerPosition()
    {
        if (transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }
        else if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }
    }

    // To shoot food from the player.
    void ShootFood()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // when spacebar is pressed, food flies out from the player.
            Instantiate(projectilePrefab, transform.position + Vector3.up, projectilePrefab.transform.rotation);
        }
    }
}
