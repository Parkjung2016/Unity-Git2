using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMove : Player
{

    [SerializeField]
    private float maximumSpeed;
    [SerializeField]
    private float maximumRunSpeed;
    [SerializeField]
    private float jumpSpeed;

    [SerializeField]
    private float jumpBtnGracePeriod;

    private float ySpeed;
    private float? lastGroundedTime;
    private float? jumpBtnPessedTime;

    public float rotation_speed;
    bool forward, back, left, right;
    int angle_to_rotete;

    private CharacterController CC;
    private GameObject Cam;
    [SerializeField]
    private LayerMask _fieldLayer;
    public bool _isGrounded;
    [SerializeField]
    private float GravitySpeed;
    public bool Jumping;
    [SerializeField]
    private Vector3 LastGroundVelocity;
    protected override void Awake()
    {
        base.Awake();
        Cam = Camera.main.gameObject;
        CC = GetComponent<CharacterController>();
    }
    private void Start()
    {
        GravitySpeed = .007f;
    }
    void Update()
    {
        calculate_angle();
        forward = Input.GetKey(KeyCode.W);
        back = Input.GetKey(KeyCode.S);
        left = Input.GetKey(KeyCode.A);
        right = Input.GetKey(KeyCode.D);
        _isGrounded = Physics.CheckSphere(transform.position, .6f, _fieldLayer);

        float Hor = Input.GetAxisRaw("Horizontal");
        float Ver = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = new Vector3(Hor, 0, Ver);
        moveDir = Quaternion.AngleAxis(Cam.transform.rotation.eulerAngles.y, Vector3.up) * moveDir;
        moveDir.Normalize();
        ySpeed += Physics.gravity.y * Time.deltaTime ;

        if(_isGrounded)
        {
            lastGroundedTime = Time.time;
        }
        if(Time.time -lastGroundedTime<=jumpBtnGracePeriod)
        {
            ySpeed -= 0.5f;

            if(Time.time-jumpBtnPessedTime<=jumpBtnGracePeriod)
            {
                ySpeed = jumpSpeed;
                
                jumpBtnPessedTime = null;
                lastGroundedTime = null;
            }

        }
        if (Anim.GetBool("Falling"))
        {
            CC.Move(LastGroundVelocity) ;
        }
    }
    public void Jump()
    {
        GravitySpeed = .2f;
        jumpBtnPessedTime = Time.time;
        Jumping = true;
            StartCoroutine(FalseJumpint());

    }
    IEnumerator FalseJumpint()
    {
        yield return new WaitForSeconds(.7f);
        Jumping = false;
    }
    private void OnAnimatorMove()
    {
        Vector3 velocity;
        if(!Anim.GetBool("Falling"))
        {
         velocity = Anim.deltaPosition*(Input.GetButton("Sprint")? maximumRunSpeed:maximumSpeed);
            velocity.y = ySpeed * Time.deltaTime*GravitySpeed ;
            //if (_isGrounded)
            //{
                LastGroundVelocity = velocity;

            //}
            CC.Move(velocity);
        }
    }
    private void FixedUpdate()
    {
        if (forward || back || right || left)
            transform.eulerAngles += new Vector3(0, Mathf.DeltaAngle(transform.eulerAngles.y, Cam.transform.eulerAngles.y + angle_to_rotete) * Time.fixedDeltaTime * rotation_speed, 0);
    }
    void calculate_angle()
    {
        if (forward && !back)
        {
            if (left && !right)
                angle_to_rotete = -45;
            else if (!left && right)
                angle_to_rotete = 45;
            else
                angle_to_rotete = 0;
        }
        else if (!forward && back)
        {
            if (left && !right)
                angle_to_rotete = -135;
            else if (!left && right)
                angle_to_rotete = 135;
            else
                angle_to_rotete = 180;
        }
        else
        {
            if (left && !right)
                angle_to_rotete = -90;
            else if (right && !left)
                angle_to_rotete = 90;
            else
                angle_to_rotete = 0;
        }
    }
}
