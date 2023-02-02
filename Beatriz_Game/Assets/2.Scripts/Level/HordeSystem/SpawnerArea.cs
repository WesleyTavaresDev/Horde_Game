using UnityEngine;

public class SpawnerArea : MonoBehaviour
{

    [SerializeField] private float vectorLength;
    
    public Vector2 GetRandomPosition() => new(GetRandomPoint(), this.gameObject.transform.position.y);

    public float GetRandomPoint() => Random.Range(this.transform.position.x, calculateLength()) + Random.Range(0.1f, 1f);
    
    private void OnDrawGizmos() {
        Gizmos.color = Color.green;

        Gizmos.DrawLine(this.gameObject.transform.localPosition, new Vector2(calculateLength(), transform.position.y));
    }

    private float calculateLength() => vectorLength - this.gameObject.transform.position.x;
}
