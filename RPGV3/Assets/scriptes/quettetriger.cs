using UnityEngine;

public class dec : MonoBehaviour
{
 void OnCollisionEnter(){
   if (gameObject.tag == "Player"){
     Debug.Log("here");
   }
 }
}