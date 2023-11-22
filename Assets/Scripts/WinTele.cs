using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTele : MonoBehaviour
{

    public GameObject Gem;
     private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Gem)
        {
            // Collect the Gem
            Gem.SetActive(false);

        SceneManager.LoadScene("Winner");
    }
  }
}
