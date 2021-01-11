using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip coin_pickup;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0, 40*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ScoreManager.Score += 5;
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(coin_pickup,transform.position);
        }
    }
}
