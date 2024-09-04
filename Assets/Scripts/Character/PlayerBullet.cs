using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet
{


    protected override void Update()
    {
        base.Update();
    }
    protected override void OnTriggerEnter(Collider other)
    {
        //base.OnTriggerEnter(other);
        if (other.TryGetComponent<EnemyBase>(out EnemyBase enemy))
        {
            enemy.DoDamage(_damage);
            DoDestroy(true);
            return;
        }
        if (other.gameObject.layer == LayerMask.NameToLayer(_obstacleLayer))
        {
            DoDestroy(false);
        }

    }
    protected override void DoDestroy(bool pShotEntity)
    {
        CounterManager.Instance.ChangeAccuracy(pShotEntity);
        base.DoDestroy(pShotEntity);
    }
}
