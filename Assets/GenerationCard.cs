using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationCard : MonoBehaviour
{
    [SerializeField] private GameObject game;
    [SerializeField] private Sprite UpSprite;
    [SerializeField] private List<Sprite> DownSprite;
    void Start()
    {
        DownSprite.AddRange(DownSprite);
        
        for(int i = 0; i < DownSprite.Count; i++)
        {
            int item = Random.Range(0, DownSprite.Count);

            Sprite itemSprite = DownSprite[i];
            DownSprite[i] = DownSprite[item];
            DownSprite[item] = itemSprite;
        }

        for(int i = 0;i < DownSprite.Count; i++)
        {
            
            Instantiate(game, transform.position, transform.rotation);
            transform.position += Vector3.right * 2f;
        }    
    }
}
