using UnityEngine;

public class AnimController : MonoBehaviour
{
    [SerializeField] private Animator pikachuAnimator;
    public bool[] animStates = new bool[3];
    void Awake()
    {
        pikachuAnimator = GetComponent<Animator>();
        animStates = new bool[3] {
            false, // Animation 1
            false, // Animation 2
            false  // Animation 3
        };
    }
    void Update()
    {
        if (pikachuAnimator != null)
        {
            pikachuAnimator.SetBool("walk", animStates[0]);
            pikachuAnimator.SetBool("jump", animStates[1]);
            pikachuAnimator.SetBool("dance", animStates[2]);
        }
        else
        {
            Debug.LogWarning("Animator component is not assigned.");
        }
    }
    public void ResetAnimations()
    {
        for (int i = 0; i < animStates.Length; i++)
        {
            animStates[i] = false;
        }
    }
    public void PlayAnimations(int animationIndex, bool state)
    {
        ResetAnimations();

        if (pikachuAnimator != null)
        {
            if (animationIndex >= 0 && animationIndex < animStates.Length)
            {
                animStates[animationIndex] = state;

            }
            else
            {
                Debug.LogWarning("Invalid animation index.");
            }
        }
        else
        {
            Debug.LogWarning("Animator component is not assigned.");
        }

    }

    public void PlayWalkAnimation()
    {
        PlayAnimations(0, true);
    }
    public void PlayJumpAnimation()
    {
        PlayAnimations(1, true);
    }
    public void PlayDanceAnimation()
    {
        PlayAnimations(2, true);
    }
}
