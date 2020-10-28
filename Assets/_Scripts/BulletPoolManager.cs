using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// TODO: Bonus - make this class a Singleton!

[System.Serializable]
public class BulletPoolManager : MonoBehaviour
{
    public GameObject bullet;

    public BulletController bulletCont;

    public int maximum_bullets;

    //TODO: create a structure to contain a collection of bullets

    Queue<GameObject> bulletsQueue = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        // TODO: add a series of bullets to the Bullet Pool

        //bulletCont.bulletPoolManager = this;



        BuildBulletPool();
    }

    private void BuildBulletPool()
    {
        for (int i = 0; i < maximum_bullets; i++)
        {
            GameObject temp = Instantiate(bullet, new Vector3(-10.0f, 0.0f, 0.0f), Quaternion.identity);
            temp.SetActive(false);
            bulletsQueue.Enqueue(temp);

        }

    }
    // Update is called once per frame
    void Update()
    {

    }

    //TODO: modify this function to return a bullet from the Pool
    public GameObject GetBullet()
    {
        Debug.Log("Getting Bullet");


        GameObject temp;
        if (!QueueIsEmpty())
        {
            temp = bulletsQueue.Dequeue();
            temp.SetActive(true);
        }
        else
        {
            temp = MonoBehaviour.Instantiate(bullet, new Vector3(-10.0f, 0.0f, 0.0f), Quaternion.identity);
            maximum_bullets += 1;
        }

        return temp;
        //return bulletsQueue.Dequeue();

        // return bullet;
    }

    //TODO: modify this function to reset/return a bullet back to the Pool 
    public void ResetBullet(GameObject bullet)
    {
        bullet.transform.position = new Vector3(-10.0f, 0.0f, 0.0f);
        bullet.SetActive(false);
        bulletsQueue.Enqueue(bullet);
    }


    public int BulletPoolSize()
    {
        return bulletsQueue.Count;
    }

    public bool QueueIsEmpty()
    {
        return bulletsQueue.Count == 0;
    }


}