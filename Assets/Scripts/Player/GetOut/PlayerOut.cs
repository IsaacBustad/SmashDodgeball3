using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOut : GetOut
{
    [SerializeField] private float outDelay = 3f;
    private WaitForSeconds delayOut;

    private void Awake()
    {
        delayOut = new WaitForSeconds(outDelay);
    }

    // player is ring out
    public override void RingOut()
    {
        effect.PlayEffect(this.gameObject.transform);
        StartCoroutine(DelayOut());
    }

    // coroutine to elim
    private IEnumerator DelayOut()
    {        
        yield return delayOut;
        GameObject.FindObjectOfType<WinLose>().LoadLose();
    }
}
