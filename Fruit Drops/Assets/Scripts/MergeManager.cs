using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeManager : MonoBehaviour
{
    #region FIELDS

    [SerializeField] private FruitCollection fruitCollection;
    private float collisionCooldown = 0.00001f;
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
    public void OnFruitCollision(Component sender, object other)
    {
        // only implement collision logic once (until cooldown has elapsed)
        if (canCollide)
        {
            StartCoroutine(CollisionCooldown());

            // switch statement for each tag
            // then when in the correct tag, call merge fruit according to tag by spawning a new fruit at location

            switch (sender.gameObject.tag)
            {
                case "Cherry":  // if current fruit is a cherry, spawn the next tier which is strawberry
                    MergeFruit(sender, other, FruitType.Strawberry);
                    break;

                case "Strawberry":
                    MergeFruit(sender, other, FruitType.Grape);
                    break;

                case "Grape":
                    MergeFruit(sender, other, FruitType.Pomegranate);
                    break;

                case "Pomegranate":
                    MergeFruit(sender, other, FruitType.Orange);
                    break;

                case "Orange":
                    MergeFruit(sender, other, FruitType.Apple);
                    break;

                case "Apple":
                    MergeFruit(sender, other, FruitType.Pear);
                    break;

                case "Pear":
                    MergeFruit(sender, other, FruitType.Peach);
                    break;

                case "Peach":
                    MergeFruit(sender, other, FruitType.Pineapple);
                    break;

                case "Pineapple":
                    MergeFruit(sender, other, FruitType.Melon);
                    break;

                case "Melon":
                    MergeFruit(sender, other, FruitType.Watermelon);
                    break;

                case "Watermelon":
                    // do nothing for now
                    break;
            }

        }
    }

    /// <summary>
    /// Instantiates the next fruit at the location of the collision to simulate merging of fruits
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="fruit"></param>
    private void MergeFruit(Component sender, object other, FruitType fruit)
    {
        // get correct prefab
        GameObject newFruit = fruitCollection.GetFruitPrefab(fruit);

        // instantiate new fruit at the location of the collision (sender)
        // note: I am subtracting a very slight amount from the collision y location in order to better simulate fruit merging
        Instantiate(newFruit, new Vector3(sender.transform.position.x, sender.transform.position.y - 0.01f, sender.transform.position.z), Quaternion.identity);
    }

}
