using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitController : MonoBehaviour
{
    #region FIELDS

    [SerializeField] private FruitCollection fruitCollection;
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

    //private void InstantiateFruit(FruitType fruit)
    //{
    //    // get correct prefab
    //    GameObject newFruit = fruitCollection.GetFruitPrefab(fruit);    // next fruit in queue would be strawberry

    //    // instantiate new fruit at the location of this current fruit
    //    Instantiate(newFruit, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
    //}

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

            //// determine which new fruit to spawn based on this fruit's tag (type)
            //switch (this.gameObject.tag)
            //{
            //    // spawn a new fruit of the next type at this fruit's location
            //    case "Cherry":
            //        //InstantiateFruit(FruitType.Strawberry);
            //        break;

            //    case "Strawberry":
            //        break;
            //}

            // *** call event that will "merge" the fruit
            // you will need to send this event info for:
            //      the tag of the fruit that collided (to determine next type),
            //      the location of the collision (for instantiating the next fruit)
            // the manager that handles this event reading will also need to implement a cooldown to make sure the event is only
            // triggered once for 2 fruit colliding

            // this would be done with a bool like canDetect that would be set to false when loigic is triggered, 
            // then would be set back to true after like 0.3 sec or something

            // destroy this fruit and fruit we collided with
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
