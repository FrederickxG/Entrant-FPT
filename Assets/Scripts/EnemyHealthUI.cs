using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthUI : MonoBehaviour
{
    public EnemyHealth enemyHealth; // Reference to the EnemyHealth script
    public Image healthBarImage;    // Reference to the Image component

    void Update()
    {
        if (enemyHealth != null && healthBarImage != null)
        {
            healthBarImage.fillAmount = enemyHealth.health / 100f;
        }
    }
}
