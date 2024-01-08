using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{

    [SerializeField] Sprite UpSprite;
    [SerializeField] Sprite DownSprite;
    [SerializeField] private float speedAngle;
    SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = UpSprite;
    }
    void Set(Sprite UpSprite, Sprite DownSprite)
    {
        this.UpSprite = UpSprite;
        this.DownSprite = DownSprite;
    }
    public void StartRotation()
    {
        StartCoroutine(rotate());
    }
    public bool equals(Card card2)
    {
        return DownSprite == card2.DownSprite;
    }
    IEnumerator rotate() 
    {
        while(transform.rotation.eulerAngles.y < 90f)
        {
            transform.Rotate(0, speedAngle * Time.fixedDeltaTime, 0);
            yield return new WaitForFixedUpdate();
        }
        if (spriteRenderer.sprite == UpSprite) spriteRenderer.sprite = DownSprite;
        else spriteRenderer.sprite = UpSprite;

        while(transform.rotation.eulerAngles.y < 180f)
        {
            transform.Rotate(0, speedAngle * Time.fixedDeltaTime, 0);
            yield return new WaitForFixedUpdate();
        }

        transform.rotation = Quaternion.Euler(0, 0, 0);
        spriteRenderer.flipX = !spriteRenderer.flipX;
        yield break;
    }
}
