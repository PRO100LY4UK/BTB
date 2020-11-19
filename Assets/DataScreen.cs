using UnityEngine;

public class DataScreen : MonoBehaviour
{
    [SerializeField] private Animation anim;

    public void ToggleScreen()
     => anim.Play();
    
}
