using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlller : MonoBehaviour
{
    [SerializeField] private Rigidbody _playerRb;
    [SerializeField] private float _speed;
    [SerializeField] private float _forcePower;
    public GameObject _powerUpIndicator;
    public GameObject _gameOver;

    //[SerializeField] private GameObject _focalPoint;

    public bool PowerUp;

    // Start is called before the first frame update
    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        //_focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {

        _powerUpIndicator.transform.position = transform.position;
        float _forwardInput = Input.GetAxis("Vertical");
        float _horizontalInput = Input.GetAxis("Horizontal");


        _playerRb.AddForce(Vector3.forward* _forwardInput * _speed,ForceMode.Impulse);
        _playerRb.AddForce(Vector3.right * _horizontalInput * _speed, ForceMode.Impulse);

        if (transform.position.y < -10)
        {
            _gameOver.SetActive(true);
            Time.timeScale = 0;
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            PowerUp = true;
            Destroy(other.gameObject);
            _powerUpIndicator.gameObject.SetActive(true);
            StartCoroutine("ForceModeCounter");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && PowerUp)
        {
            Debug.Log("ENEMY ÇARPTIM"+PowerUp);
            Rigidbody _enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayfromplayer = (collision.gameObject.transform.position - transform.position);

            _enemyRb.AddForce(awayfromplayer*_forcePower,ForceMode.Impulse);
        }
    }

    private IEnumerator ForceModeCounter()
    {
        yield return new WaitForSeconds(7);
        PowerUp = false;
        _powerUpIndicator.gameObject.SetActive(false);
    }

    
}

