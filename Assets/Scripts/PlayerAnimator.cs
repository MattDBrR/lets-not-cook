using UnityEngine;

public class PlayerAnimator : MonoBehaviour{
    private const string IS_WALKING = "IsWalking";
    private Animator animator;
    private Player player;
    
    private void Awake()
    {
        // Search for Animator in this GameObject or children
        animator = GetComponent<Animator>();
        
        if (animator == null)
        {
            animator = GetComponentInChildren<Animator>();
        }
        
        player = GetComponent<Player>();
    }

    private void Update()
    {
        if (player != null && animator != null)
        {
            bool isWalking = player.IsWalking();
            animator.SetBool(IS_WALKING, isWalking);
        }
    }
}