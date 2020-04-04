using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float jumpHeight = 2f;
    public float groundDistance = 0.2f;
    public float dashDistance = 5f;
    public LayerMask ground;

    private Rigidbody _body;
    private Vector3 _inputs = Vector3.zero;
    private bool _isGrounded = false;
    private Transform _groundChecker;

    [SerializeField] float _jumpPower = 12f;

    void Start()
    {
        _body = GetComponent<Rigidbody>();
        _groundChecker = transform.GetChild(0);
        foreach (Transform child in transform)
        {
            Debug.Log("child: " + child);
        }
    }

    void Update()
    {
        _isGrounded = Physics.CheckSphere(_groundChecker.position, groundDistance, ground, QueryTriggerInteraction.Ignore);
        _inputs = Vector3.zero;
        _inputs.x = Input.GetAxis("Horizontal");
        _inputs.z = Input.GetAxis("Vertical");

        //Debug.Log("is Grounded? : "+_isGrounded);

        if (_inputs != Vector3.zero)
            transform.forward = _inputs;

        if (Input.GetButtonDown("Jump") /* && _isGrounded */)
        {
            _body.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
        }

        if (Input.GetButtonDown("Fire3"))
        {
            Vector3 dashVelocity = Vector3.Scale(transform.forward, dashDistance * new Vector3((Mathf.Log(1f / (Time.deltaTime * _body.drag + 1)) / -Time.deltaTime), 0, (Mathf.Log(1f / (Time.deltaTime * _body.drag + 1)) / -Time.deltaTime)));
            _body.AddForce(dashVelocity, ForceMode.VelocityChange);
        }
    }


    void FixedUpdate()
    {
        _body.MovePosition(_body.position + _inputs * moveSpeed * Time.fixedDeltaTime);
    }

    void HandleGroundedMovement(bool crouch, bool jump)
    {
        // check whether conditions are right to allow a jump:
        if (jump && !crouch )
        {
            // jump!
            _body.velocity = new Vector3(_body.velocity.x, _jumpPower, _body.velocity.z);
            _isGrounded = false;
        }
    }
}
