using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeysCollect : MonoBehaviour
{
    public bool rotate = true; // do you want it to rotate?
    public float rotationSpeed = 50;
    public GameObject collectEffect;
    private ScoreCounter scoreCounter;

    void Start()
    {
        scoreCounter = FindObjectOfType<ScoreCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rotate)
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            CollectKey();
        }
    }

    public void CollectKey()
    {
        if (collectEffect)
        {
            Instantiate(collectEffect, transform.position, Quaternion.identity);
        }

        scoreCounter.IncScore();
        Destroy(gameObject);
    }
}
