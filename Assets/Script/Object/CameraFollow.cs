using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector3 offset = new Vector3(3f, 4f, -10f);
    public float smoothTime = 0.2f;    // 부드러움 정도 (0.1~0.5 추천)

    private Vector3 velocity = Vector3.zero;
    private Transform target;

    void Start()
    {
        if (target == null)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
                target = player.transform;
        }
    }

    void LateUpdate()
    {
        if (target == null) return;

        // 목표 위치 계산
        Vector3 targetPosition = target.position + offset;

        // 카메라 위치를 부드럽게 목표 위치로 이동
        transform.position = Vector3.SmoothDamp(
            transform.position,
            targetPosition,
            ref velocity,
            smoothTime
        );
    }
}
