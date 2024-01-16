using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMusicStop : MonoBehaviour
{
    public InteractTest interactTest;

    private void OnDestroy()
    {
        interactTest.StopBossMusic();
    }
}
