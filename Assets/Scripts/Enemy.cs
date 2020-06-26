using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MovingObject
{
    public int playerDamage;
    private Animator animator;
    private Transform target;
    private bool skipTurn;

    protected override void OnCantMove<T>(T component)
    {
        animator.SetTrigger("EnemyAttack");
        Player hitPlayer = component as Player;
        hitPlayer.LoseFood(playerDamage);
    }

    protected override void AttemptMove<T>(int xDir,int yDir)
    {
       if (skipTurn)
        {
            skipTurn = false;
            return;
        }
        base.AttemptMove<T>(xDir, yDir);
        skipTurn = true;
    }

    public void MoveEnemy()
    {
        int xDir = 0;
        int yDir = 0;
        if (Mathf.Abs(target.position.x - transform.position.x) < float.Epsilon)
            yDir = target.position.y > transform.position.y ? 1 : -1;
        else
            xDir = target.position.x > transform.position.x ? 1 : -1;
        AttemptMove<Player>(xDir, yDir);
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        GameManger.instance.AddEnemyToList(this);
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        base.Start();
    }
}
