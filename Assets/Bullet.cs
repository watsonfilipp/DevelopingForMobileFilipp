using UnityEngine;


//Script to properly reference the damage and the health on the target objects
public class Bullet : MonoBehaviour
{
    private int bulletDamage;
    
    public void SetBulletDamage(int damage)
    {
        bulletDamage = damage;
    }

   
    public int GetBulletDamage()
    {
        return bulletDamage;
    }
}
