using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    private int HP = 100;

    public Animator animator;
    public Slider heathBar;

    private void Update()
    {
        heathBar.value = HP;
    }

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
        if (HP <= 0)
        {
            Die();
        }
        else
        {
            animator.SetTrigger("Damage");
        }
    }

    private void Die()
    {
        animator.SetTrigger("Die");
        GetComponent<Collider>().enabled = false;
    }
}
