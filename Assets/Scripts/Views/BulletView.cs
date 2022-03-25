using UnityEngine;

public class BulletView : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.GetComponent<EnemyTankView>())
        {
            other.gameObject.GetComponent<EnemyTankView>()._enemyTankController.TakeDamage(100);
           Debug.Log(other.gameObject.GetComponent<EnemyTankView>()._enemyTankController._tankModel.Health);
        }
    }  
}
