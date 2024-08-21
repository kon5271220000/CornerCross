using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float minRotateSpeed;
    [SerializeField] private float maxRotateSpeed;
    private float currentRotateSpeed;

    [SerializeField] private float minRotateTime;
    [SerializeField] private float maxRotateTime;
    private float currentRotateTime;
    private float rotateTime;


    private void Awake()
    {
        currentRotateTime = 0f;
        currentRotateSpeed = minRotateSpeed + (maxRotateSpeed - minRotateSpeed) * 0.1f * Random.Range(0,11);
        rotateTime = minRotateTime + (maxRotateTime - minRotateTime) * 0.1f * Random.Range(0, 11);
        currentRotateSpeed *= Random.Range(0, 2) == 0 ? 1: -1f;
    }

    private void Update()
    {
        currentRotateTime += Time.deltaTime;

        if(currentRotateTime > rotateTime)
        {
            currentRotateTime = 0f;
            currentRotateSpeed = minRotateSpeed + (maxRotateSpeed - minRotateSpeed) * 0.1f * Random.Range(0, 11);
            rotateTime = minRotateTime + (maxRotateTime - minRotateTime) * 0.1f * Random.Range(0, 11);
            currentRotateSpeed *= Random.Range(0, 2) == 0 ? 1 : -1f;
        }
    }

    private void FixedUpdate()
    {
        transform.Rotate(0, 0, currentRotateSpeed * Time.fixedDeltaTime);
    }
}
