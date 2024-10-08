using UnityEngine;

public abstract class AbstractAnim : MonoBehaviour
{
    public Animator _targetAnimator;
    
    public abstract void PLayHitAnimation();
}
