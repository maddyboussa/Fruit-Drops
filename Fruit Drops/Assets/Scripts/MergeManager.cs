using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeManager : MonoBehaviour
{
    #region FIELDS

    [SerializeField] private FruitCollection fruitCollection;
    [SerializeField] float collisionCooldown = 0.5f;
    private bool canCollide = true;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Coroutine starts a cooldown in which collisions will not be registered
    /// </summary>
    /// <returns></returns>
    IEnumerator CollisionCooldown()
    {
        // make sure collisions will not be detected until cooldown has finished
        canCollide = false;
        yield return new WaitForSeconds(collisionCooldown);
        canCollide = true;
    }

    /// <summary>
    /// When onFruitCollision event is triggered,
    /// checks if a collision can be registered, and then merges fruit according to the sender's tag
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="data"></param>
    public void OnFruitCollision(Component sender, object data)
    {
        // only implement collision logic once (until cooldown has elapsed)
        if (canCollide)
        {
            StartCoroutine(CollisionCooldown());
            Debug.Log("merging now");

            // switch statement for each tag
            // then when in the correct tag, call merge fruit according to tag

            switch (sender.gameObject.tag)
            {
                case "Cherry":
                    break;

                case "Strawberry":
                    break;

                case "Grape":
                    break;

                //case "Cherry":
                //    break;

                //case "Cherry":
                //    break;

                //case "Cherry":
                //    break;

                //case "Cherry":
                //    break;
            }

        }
    }

    /// <summary>
    /// Instantiates the next fruit at the location of the collision to simulate merging of fruits
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="fruit"></param>
    private void MergeFruit(Component sender, FruitType fruit)
    {
        // get correct prefab
        GameObject newFruit = fruitCollection.GetFruitPrefab(fruit);

        // instantiate new fruit at the location of the collision (sender)
        Instantiate(newFruit, new Vector3(sender.transform.position.x, sender.transform.position.y, sender.transform.position.z), Quaternion.identity);
    }

}
