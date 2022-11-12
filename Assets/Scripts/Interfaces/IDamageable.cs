using UnityEngine;

public interface IDamageable
{
    public float health { set; get; }
    
    public void OnHit(float damage);

} 
