using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public Rigidbody2D theRB;
    public Camera viewCam;
    public Animator gunAnim;
    public Animator playerAnim; //generic, maybe change to smth more specific, related 

    public GameObject bulletImpact;

    private Vector2 moveInput;
    private Vector2 mouseInput;

    public float moveSpeed = 5f;
    public float mouseSensitivity = 1f;

    //Trying
    float maxAngle = 160;
    float minAngle = 10;

    public int currentAmmo = 15;

    public int currentHealth;
    private bool hasDied;
    public int maxHealth = 100;
    public GameObject deadScreen;

    public TMP_Text healthText, ammoText;

    private void Awake() 
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();

        ammoText.text = currentAmmo.ToString();
    }

    // Update is called once per frame
    void Update()
    {   
        if(!hasDied)
        {
            //Player Movement
            moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            Vector3 moveHorizontal = transform.up * -moveInput.x;
            Vector3 moveVertical = transform.right * moveInput.y;

            theRB.velocity = (moveHorizontal + moveVertical) * moveSpeed;


            //Player View control
            mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;

            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - mouseInput.x); //These two lines are the same idea, but with different implementations
            viewCam.transform.localRotation = Quaternion.Euler(viewCam.transform.localRotation.eulerAngles + new Vector3(0f, mouseInput.y, 0f));

            //Camera clamp, no 360 rotation on the Y axis (in our case, the Z axis)
            Vector3 RotAmount = viewCam.transform.localRotation.eulerAngles + new Vector3 (0f, mouseInput.y, 0f);
            viewCam.transform.localRotation = Quaternion.Euler(RotAmount.x, Mathf.Clamp(RotAmount.y, minAngle , maxAngle) , RotAmount.z);

            //Player Shooting
            if(Input.GetMouseButtonDown(0))
            {
                if(currentAmmo > 0){
                    Ray ray = viewCam.ViewportPointToRay(new Vector3(.5f, .5f, 0f));
                    RaycastHit hit;

                    currentAmmo--;
                    gunAnim.SetTrigger("Shoot");
                    AudioController.instance.PlayAudio(AudioController.instance.gunShot);

                    if(Physics.Raycast(ray, out hit))
                    {
                        Instantiate(bulletImpact, hit.point, transform.rotation);
                
                        if(hit.transform.tag == "Enemy")
                        {
                            hit.transform.parent.GetComponent<EnemyController>().TakeDamage();
                        }
                    }
                }
                UpdateAmmoUI();
            }

            //Head bobb animation
            if(moveInput != Vector2.zero){
                playerAnim.SetBool("isMoving", true);
            } else 
            {
                playerAnim.SetBool("isMoving", false);
            }
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if(currentHealth <= 0)
        {
            deadScreen.SetActive(true);
            hasDied = true;
            currentHealth = 0;
        } 

        AudioController.instance.PlayAudio(AudioController.instance.playerHurt);
        UpdateHealthUI();
    }

    public void AddHealth(int healAmount)
    {
        currentHealth += healAmount;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        UpdateHealthUI();
    }

    public void UpdateAmmoUI()
    {
        ammoText.text = currentAmmo.ToString();
    }

    public void UpdateHealthUI()
    {
        healthText.text = currentHealth.ToString() + " %";
    }
}
