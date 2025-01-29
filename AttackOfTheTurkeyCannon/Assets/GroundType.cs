using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundType : MonoBehaviour
{
    public enum GravityType { Normal, Low, Quicksand }
    public GravityType groundEffect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null)
            {
                switch (groundEffect)
                {
                    case GravityType.Normal:
                        player.SetGravity(1.0f);
                        break;
                    case GravityType.Low:
                        player.SetGravity(0.5f);
                        break;
                    case GravityType.Quicksand:
                        player.SetGravity(2.0f);
                        break;
                }
            }
        }
    }
}
