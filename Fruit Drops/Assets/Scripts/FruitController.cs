using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitController : MonoBehaviour
{
    #region FIELDS

    [SerializeField] private GameEvent onFruitCollision;
    private bool hasCollided;
    [SerializeField] private GameObject spawner;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        hasCollided = false;

        // make sure all fruit ignore collisions with spawner
        Physics2D.IgnoreCollision(GetComponent<CircleCollider2D>(), spawner.GetComponent<CircleCollider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /// <summary>
    /// Checks for collision between fruit and others of its kind when triggered by colliders
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
}
