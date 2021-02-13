using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] Transform _targetA, _targetB;
    float _speed = 3.0f;
    bool _switching = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(_switching == false){
            transform.position = Vector3.MoveTowards(transform.position, _targetB.position, _speed * Time.deltaTime);
        }
        else if(_switching == true){
            transform.position = Vector3.MoveTowards(transform.position, _targetA.position, _speed * Time.deltaTime);
        }

        if(transform.position == _targetB.position){
            _switching = true;
        }
        else if(transform.position == _targetA.position){
            _switching = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player"){
            other.transform.parent = this.transform;
        }
    }

    /// <summary>
    /// OnTriggerExit is called when the Collider other has stopped touching the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player"){
            other.transform.parent = null;
        }
    }
}
