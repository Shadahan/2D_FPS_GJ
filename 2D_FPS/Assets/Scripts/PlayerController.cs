using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public Rigidbody2D theRB;
    public Camera viewCam;
    public Animator gunAnim;

    public GameObject bulletImpact;

    private Vector2 moveInput;
    private Vector2 mouseInput;

    public float moveSpeed = 5f;
    public float mouseSensitivity = 1f;
    public int currentAmmo = 15;

    private void Awake() 
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   //Player Movement
        moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Vector3 moveHorizontal = transform.up * -moveInput.x;
        Vector3 moveVertical = transform.right * moveInput.y;

        theRB.velocity = (moveHorizontal + moveVertical) * moveSpeed;


        //Player View control
        mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - mouseInput.x); //These two lines are the same idea, but with different implementations
        viewCam.transform.localRotation = Quaternion.Euler(viewCam.transform.localRotation.eulerAngles + new Vector3(0f, mouseInput.y, 0f));


        //Player Shooting
        if(Input.GetMouseButtonDown(0))
        {
            if(currentAmmo > 0){
                Ray ray = viewCam.ViewportPointToRay(new Vector3(.5f, .5f, 0f));
                RaycastHit hit;
                if(Physics.Raycast(ray, out hit))
                {
                    Instantiate(bulletImpact, hit.point, transform.rotation);
                
                    if(hit.transform.tag == "Enemy")
                    {
                        hit.transform.parent.GetComponent<EnemyController>().TakeDamage();
                    }
                } else 
                {
                Debug.Log("I'm looking at nothing");
                }
            }

            currentAmmo--;
            gunAnim.SetTrigger("Shoot");
        }
    }
}
