using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] float time = 1f;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        StartCoroutine(AnimationWait(time));
    }

    IEnumerator AnimationWait(float time)
    {
        yield return new WaitForSeconds(time);

        anim.SetBool("Active", true);
    }
}
