using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int totalHealth = 3;
    public int health;
    private SpriteRenderer _renderer;
    // Start is called before the first frame update
    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        health = totalHealth;
    }
    public void AddDamage(int amount)
    {
        health = health - amount;

        StartCoroutine("VisualFeedback");

        if(health <= 0){
            health = 0;
        }
        Debug.Log("Player got damaged. His Current health is" + health);
    }

    public void AddHealth(int amount)
    {
        health = health + amount;
        //max health
        if(health > totalHealth){
            health = totalHealth;
        }
        Debug.Log("Player got some life. His Current health is" + health);
    }
    private IEnumerator VisualFeedback(){
        _renderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        _renderer.color = Color.white;
    }
}
