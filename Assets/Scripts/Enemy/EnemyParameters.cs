public class EnemyParameters : AbstractParameters
{
    private EnemyAnimation _enemyAnimator;
    private EnemySound _enemySound;

    private void Start()
    {
        _enemyAnimator = GetComponent<EnemyAnimation>();
        _enemySound = GetComponent<EnemySound>();
    }

    public override void TakeHit()
    {
        _enemyAnimator.PLayHitAnimation();
        _enemySound.PlayHitSound();
    }
}
