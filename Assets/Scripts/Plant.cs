using UnityEngine;
using System.Collections;

public class Plant : MonoBehaviour {

    private float animatorSpeed;
    private Animator animator;

    void Start () {

        animator = GetComponent<Animator>();
        animatorSpeed = animator.speed;
        animator.speed = UnityEngine.Random.Range(0, 2000);
        StartCoroutine(animatorWait());
    }

    private IEnumerator animatorWait()
    {
        yield return new WaitForSeconds(0.1f);
        animator.speed = animatorSpeed;
    }
}
