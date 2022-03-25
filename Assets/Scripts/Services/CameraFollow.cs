using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
   Transform player;

   private void Update() {
       if(player!=null)
       {
            gameObject.transform.position = new Vector3(player.position.x, player.position.y, 0);
       }
       else
       {
            player = GameObject.FindGameObjectWithTag("Player").transform;
       }
      
   }
}
