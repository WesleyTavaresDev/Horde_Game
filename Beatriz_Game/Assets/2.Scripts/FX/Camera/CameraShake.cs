using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Transform cameraPosition;

    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 origin = this.gameObject.transform.position;

        float time = 0f;

        while(time < duration )
        {
            cameraPosition.position = new Vector3(origin.x + Random.insideUnitCircle.x * magnitude, origin.y + Random.insideUnitCircle.y * magnitude, -10); 
            time += Time.deltaTime;

            yield return null;
        }

        cameraPosition.position = new Vector3(0, 0, -10);
    }
}
