using UnityEngine;

public class AnimatorBehavior : MonoBehaviour
{
    public Animator animator;
    public string boolName = "myBool";

    public void SetBool(bool value)
    {
        animator.SetBool(boolName, value);
    }
}
