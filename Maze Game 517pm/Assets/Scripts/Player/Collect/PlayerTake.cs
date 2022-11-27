using UnityEngine;

public class PlayerTake : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
         TODO: 
         Check for collectness
         */

        ScoreSaver.AddScore();
    }
}
