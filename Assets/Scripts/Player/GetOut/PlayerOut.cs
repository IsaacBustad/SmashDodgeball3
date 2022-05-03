using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOut : GetOut
{
    [SerializeField] private float outDelay = 3f;
    private WaitForSeconds delayOut;
    private Singleton instance = Singleton.Instance;

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
        instance.RemoveObserver(gameObject.GetComponent<CharacterBroadcast>());
        yield return delayOut;
        GameObject.FindObjectOfType<WinLose>().LoadLose();
    }
}
