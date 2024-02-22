using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
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
            animator.SetTrigger("Die");
            GetComponent<Collider>().enabled = false;
        }
        else
        {
            animator.SetTrigger("Damage");
        }
    }
}
