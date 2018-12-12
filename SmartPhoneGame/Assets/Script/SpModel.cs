using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpModel : MonoBehaviour {

    private Animator animator;

    void Start ()
    {
        animator = GetComponent<Animator>();
        AniT();
    }
	
	void Update () {
		
	}

    void AniF()
    {
        animator.SetBool("Take 001", false);
    }

    void AniT()
    {
        animator.SetBool("Take 001", true);
    }
}
