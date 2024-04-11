using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillMensen : MonoBehaviour
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
        yield return new WaitForSeconds(5);
        if(mAnimator != null)
        {
            mAnimator.Play("mensen ga weg");
            yield return new WaitForSeconds(5);
            Destroy(this.gameObject);
        
        }
        
    }
}
