using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPanda : MonoBehaviour
{

    private Animator mAnimator;
    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(DestroyMe());
    }

    IEnumerator DestroyMe()
    {
        yield return new WaitForSeconds(7);
        if(mAnimator != null)
        {
            mAnimator.Play("pandarev");
            yield return new WaitForSeconds(2);
        
        }
        Destroy(this.gameObject);
    }
}
