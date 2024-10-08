using UnityEngine;

public class EnemyAnimation : AbstractAnim
{
    public void Start() => _targetAnimator = GetComponent<Animator>();

    public override void PLayHitAnimation() => _targetAnimator.SetTrigger("Hit");
}
