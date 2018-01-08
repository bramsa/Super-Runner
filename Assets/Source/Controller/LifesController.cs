using UnityEngine;

/// <summary>
/// This controller handles the lifes of the player.
/// </summary>
public class LifesController : MonoBehaviour
{

    public int lifes;

    /// <summary>
    /// Set lifes to 2
    /// </summary>
    void SetLifes()
    {
        lifes = 2;
    }

    /// <summary>
    /// When the player touches an obstacle, he looses one life.
    /// </summary>
    public void OnObstacleTouched()
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

    /// <summary>
    /// If the player has no lifes left.
    /// </summary>
    void GameOver()
    {
       // Destroy(gameObject);
    }
}