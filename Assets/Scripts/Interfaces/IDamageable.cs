using UnityEngine;

public interface IDamageable
{
    public float Health { set; get; }

    public void OnHit(float damage);

} 
