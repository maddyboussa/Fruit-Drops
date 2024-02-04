using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitController : MonoBehaviour
{
    #region FIELDS

    [SerializeField] private GameEvent onFruitCollision;
    private bool hasCollided;

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
    /// Checks for collision between fruit and others of its kind when triggered by colliders
    /// </summary>
    /// <param name="other"></param>
    private void OnCollisionEnter2D(Collision2D other)
    {
        // check if colliding with prefab of the same fruit type
        // also check to make sure fruit has not already collided with this object
        if (other.gameObject.CompareTag(this.gameObject.tag) && !hasCollided)
        {
            hasCollided = true;

            // broadcast fruit collision event with the appropriate data (sender and tag of sender)
            onFruitCollision.Raise(this, this.gameObject.tag);

            // destroy this fruit and fruit we collided with
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
