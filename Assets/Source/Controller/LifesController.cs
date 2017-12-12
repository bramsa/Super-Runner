using UnityEngine;

public class LifesController : MonoBehaviour
{

    public int lifes;

    // set lifes to 2
    void SetLifes()
    {
        lifes = 2;
    }

    void OnObstacleTouched()
    {
        // minus 1 life on collision
        lifes--;

        // run GameOver-method when lifes == 0
        if (lifes == 0)
        {
            SendMessage("OnPlayerDies");
            GameOver();
        }
    }

    void GameOver()
    {
        Destroy(gameObject);
    }
}