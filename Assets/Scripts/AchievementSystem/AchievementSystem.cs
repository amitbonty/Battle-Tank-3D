using System.Collections;
using UnityEngine;
using System.Collections.Generic;


public class AchievementSystem : Singleton<AchievementSystem>
{
    [SerializeField]
    private GameObject bulletsTxt;
    [SerializeField]
    private GameObject bulletsTxt2;
    [SerializeField]
    private GameObject bulletsTxt3;

    public IEnumerator ShowPopup1()
    {
        bulletsTxt.SetActive(true);
        yield return new WaitForSeconds(2f);
        bulletsTxt.SetActive(false);
    }
    public IEnumerator ShowPopup2()
    {
        bulletsTxt2.SetActive(true);
        yield return new WaitForSeconds(2f);
        bulletsTxt2.SetActive(false);
    }
    public IEnumerator ShowPopup3()
    {
        bulletsTxt3.SetActive(true);
        yield return new WaitForSeconds(2f);
        bulletsTxt3.SetActive(false);
    }
    
}
