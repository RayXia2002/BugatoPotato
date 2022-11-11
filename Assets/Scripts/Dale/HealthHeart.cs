using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthHeart : MonoBehaviour
{
    public Sprite fullHeart, halfHeart, emptyHeart;
    Image heartImage;

    private void Awake()
    {
        heartImage = GetComponent<Image>();
    }

    public void SetHeartImage(HeartStatus status)
    {
        if (status == HeartStatus.Empty)
        {
            heartImage.sprite = emptyHeart;
        }
        else if (status == HeartStatus.Half)
        {
            heartImage.sprite = halfHeart;
        }
        else
        {
            heartImage.sprite = fullHeart;
        }
    }
}

public enum HeartStatus
{
    Empty = 0,
    Half = 1,
    Full = 2
}
