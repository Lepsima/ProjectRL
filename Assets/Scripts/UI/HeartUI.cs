using UnityEngine;
using UnityEngine.UI;

public class HeartUI : MonoBehaviour
{
    [SerializeField] private Image heartimage;

    [SerializeField] private bool isActive;


    public void is_Active()
    {
        heartimage.enabled = true;
        isActive = true;
    }

    public void DisableHeart()
    {
        heartimage.enabled = false;
        isActive = false;
    }

    public bool EstaActivo() => isActive;
}
