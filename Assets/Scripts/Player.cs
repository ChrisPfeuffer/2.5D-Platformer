using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController _controller;
    float _gravity = 0.25f;
    [SerializeField] float _speed = 5.0f;
    float _jumpHeight = 15.0f;
    float _yVelocity;
    [SerializeField] bool _canDoubleJump = false;
    [SerializeField] int _coins;
    UIManager _uiManager;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if(_uiManager == null){
            Debug.Log("UIManager is null");
        }

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInput, 0, 0);
        Vector3 velocity = direction * _speed;

        if(_controller.isGrounded == true)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
                _canDoubleJump = true;
            }
        }
        else
        {

            if(Input.GetKeyDown(KeyCode.Space))
            {
                if(_canDoubleJump == true)
                {
                _yVelocity += _jumpHeight;
                _canDoubleJump = false;
                }
            }

            _yVelocity -= _gravity;
        }

        velocity.y = _yVelocity;

        _controller.Move(velocity * Time.deltaTime);
    }

    public void AddCoins(){
        _coins++;

        _uiManager.UpdateCoinDisplay(_coins);
    }

}
