using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Player myPlayer;
    private bool isUsingPowerUpGun;

    //public Camera mainCamera;
    public Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        myPlayer = GetComponent<Player>();
        myPlayer.OnPowerUp.AddListener(UsePowerUp);
        myPlayer.OnPowerUpEnd.AddListener(UserNormalWeapon);
        isUsingPowerUpGun = false;
    }

    private void Update()
    {
        if (!isUsingPowerUpGun)
        {
            if (Input.GetMouseButtonDown(0))
            {
                myPlayer.Attack();
            }
        } else if(isUsingPowerUpGun)
        {
            if (Input.GetMouseButton(0))
            {

                myPlayer.PowerUpAttack();
            }
        }
        
        if(Input.GetMouseButtonDown(1))
        {
            myPlayer.UseNuke();
        }
    }

    private void UsePowerUp()
    {
        isUsingPowerUpGun = true;
    }

    private void UserNormalWeapon()
    {
        isUsingPowerUpGun = false;
    }



    // Update is called once per frame
    //Use fixed update for smoother physics (rigidbody) movement
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        //10 is the position of the main camera
        //camera is -10 away from actual objects so use 10 to go back to objects on stage.
        //mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));

        direction = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)); ;
        float angleToRotate =  Mathf.Atan2(direction.y - transform.position.y, direction.x - transform.position.x) * Mathf.Rad2Deg;

        myPlayer.Move(new Vector2(horizontalInput, verticalInput), angleToRotate);

    }
}
