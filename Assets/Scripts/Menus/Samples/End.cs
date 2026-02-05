using System;
using UnityEngine;

namespace Menus.Samples
{
    public class End : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                LevelManager.Instance.LoadScene("End", "CrossFade");
                MusicManager.Instance.PlayMusic("Main Menu");
            }
        }
    }
}