using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitController : MonoBehaviour
{
    #region FIELDS

    [SerializeField] private GameEvent onFruitCollision;
    private bool hasCollided;

    [SerializeField] private GameEvent addDangerCollision;
    [SerializeField] private GameEvent removeDangerCollision;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        hasCollided = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /// <summary>
    /// Listens for collision between fruit and others of its kind when triggered by colliders
    /// </summary>
    /// <param name="other"></param>
    private void OnCollisionEnter2D(Collision2D other)
    {
        // check if colliding with prefab of the same fruit type
        // also check to make sure fruit has not already collided with this object
        if (other.gameObject.CompareTag(this.gameObject.tag) && !hasCollided)
        {
            // verify that colliding fruits are not watermelons, as they are the last tier and should not be merged
            if (!this.gameObject.tag.Equals("Watermelon"))
            {
                hasCollided = true;

                // broadcast fruit collision event with the appropriate data (sender and object we are colliding with)
                onFruitCollision.Raise(this, other);

                // destroy this fruit and fruit we collided with
                Destroy(other.gameObject);
                Destroy(this.gameObject);
            }
        }
    }

    /// <summary>
    /// Listens for entry collision between collider and trigger collider
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        // ensure colliding with danger box
        if (other.gameObject.CompareTag("DangerZone"))
        {
            // raise add event
            addDangerCollision.Raise(this, other);

            // change color to red to indicate inside danger zone
            // eventually, it will add/remove a shader to outline the object in red
            GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    /// <summary>
    /// Listens for exit collision between collider and trigger collider
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DangerZone"))
        {
            // raise remove event
            removeDangerCollision.Raise(this, other);

            // change color back to default (white)
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
