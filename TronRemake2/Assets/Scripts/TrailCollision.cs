using System.Collections;
using UnityEngine;

public class TrailCollision : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        IEnumerator DelayCollider()
        {
            yield return new WaitForSeconds(.25f);
            this.GetComponent<Collider>().enabled = true;
        }

        StartCoroutine(DelayCollider());
    }
}
