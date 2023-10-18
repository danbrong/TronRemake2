using System.Collections;
using UnityEngine;

public class TrailCollision : MonoBehaviour
{
    public float colliderDelay;
    // Update is called once per frame
    void Update()
    {
        IEnumerator DelayCollider()
        {
            yield return new WaitForSeconds(.30f);
            this.GetComponent<Collider>().enabled = true;
        }

        StartCoroutine(DelayCollider());
    }
}
