using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitController : MonoBehaviour
{
    #region FIELDS


    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // check if colliding with prefab of the same fruit type
        if (other.gameObject.CompareTag(this.gameObject.tag))
        {
            Debug.Log("same tag");

            // determine which new fruit to spawn based on this fruit's tag (type)
            switch (this.gameObject.tag)
            {
                // spawn a new fruit of the next type at this fruit's location
                case "Cherry":
                    
                    break;

                case "Strawberry":
                    break;
            }

            // destroy this fruit and fruit we collided with
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
