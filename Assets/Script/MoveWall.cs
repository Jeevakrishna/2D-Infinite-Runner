using UnityEngine;

public class MoveWall : MonoBehaviour
{

   public float  WallMoveSpeed;
    private void Update()
    {
        transform.position += Vector3.left * WallMoveSpeed * Time.deltaTime;
    }
}
