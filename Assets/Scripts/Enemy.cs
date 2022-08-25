using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Rigidbody _enemyRb;
    [SerializeField] private GameObject _player;
    [SerializeField] public float _speed;

   
    // Start is called before the first frame update
    void Start()
    {

        _player = GameObject.Find("Player");
        _enemyRb = GetComponent<Rigidbody>();
        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 lookDirection = (_player.transform.position - transform.position).normalized;
        _enemyRb.AddForce((lookDirection).normalized*_speed);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    
}
