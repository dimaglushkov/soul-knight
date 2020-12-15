using UnityEngine;

public class HealthController : MonoBehaviour
{
    public SpriteRenderer heart1;
    public SpriteRenderer heart2;
    public SpriteRenderer heart3;


    public void UpdateHearts(int health)
    {
        heart1.enabled = health > 0;
        heart2.enabled = health > 1;
        heart2.enabled = health > 2;
    }
    
}
