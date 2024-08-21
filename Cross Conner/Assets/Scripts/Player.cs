using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;
    [SerializeField] private AudioClip moveClip, looseClip;

    [SerializeField] private GamePlayManager gamePlayManager;
    [SerializeField] private GameObject explosionPref;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            SoundManager.instance.PlaySound(moveClip);
            rotateSpeed *= -1;
        }
    }

    private void FixedUpdate()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Instantiate(explosionPref, transform.GetChild(0).position,Quaternion.identity);
            SoundManager.instance.PlaySound(looseClip);
            gamePlayManager.GameEnded();
            Destroy(gameObject);
        }
    }
}
