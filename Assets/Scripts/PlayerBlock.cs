using UnityEngine;
using UnityEngine.UI;

public class PlayerBlock : MonoBehaviour
{
    public KeyCode blockKey = KeyCode.F;
    public float blockDuration = 5f;
    public float blockCooldownDuration = 10f; // Cooldown period after blocking
    public Image blockBar; // Reference to the Image component of the block bar

    private bool isBlocking = false;
    private bool isHoldingBlockKey = false;
    private float remainingBlockTime = 0f;
    private float remainingCooldownTime = 0f;

    private void Update()
    {
        // Check if block key is being held
        isHoldingBlockKey = Input.GetKey(blockKey);

        // Start blocking when the block key is held and not already blocking
        if (isHoldingBlockKey && !isBlocking && remainingCooldownTime <= 0f)
        {
            StartBlocking();
        }

        // Stop blocking and start cooldown when the block key is released
        if (!isHoldingBlockKey && isBlocking)
        {
            EndBlocking();
            StartCooldown();
        }

        // Update block and cooldown timers
        if (isBlocking)
        {
            UpdateBlockTimer();
        }
        else if (remainingCooldownTime > 0f)
        {
            UpdateCooldownTimer();
        }
    }

    public bool IsBlocking()
    {
        return isBlocking;
    }

    private void StartBlocking()
    {
        isBlocking = true;
        remainingBlockTime = blockDuration;

        // Set block bar fill amount to full when starting blocking
        blockBar.fillAmount = 1f;
    }

    private void EndBlocking()
    {
        isBlocking = false;
    }

    private void UpdateBlockTimer()
    {
        remainingBlockTime -= Time.deltaTime;

        // Update block bar fill amount based on remaining block time
        float fillAmount = Mathf.Clamp01(remainingBlockTime / blockDuration);
        blockBar.fillAmount = fillAmount;

        // If block time is up, end blocking and start cooldown
        if (remainingBlockTime <= 0f)
        {
            EndBlocking();
            StartCooldown();
        }
    }

    private void StartCooldown()
    {
        remainingCooldownTime = blockCooldownDuration;
    }

    private void UpdateCooldownTimer()
    {
        remainingCooldownTime -= Time.deltaTime;

        // Gradually refill block bar during cooldown
        float fillAmountIncrement = Time.deltaTime / blockCooldownDuration;
        blockBar.fillAmount = Mathf.Clamp01(blockBar.fillAmount + fillAmountIncrement);

        // If cooldown is over, reset blocking ability
        if (remainingCooldownTime <= 0f)
        {
            remainingCooldownTime = 0f;
            blockBar.fillAmount = 0f;
        }
    }
}
