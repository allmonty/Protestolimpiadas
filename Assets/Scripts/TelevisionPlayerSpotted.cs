using UnityEngine;
using System.Collections;

public class TelevisionPlayerSpotted : MonoBehaviour {

    GameObject player;
    ScoreManager scoreManager;
    Camera tvCamera;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        tvCamera = gameObject.GetComponentInChildren<Camera>();
    }

    void Update()
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(tvCamera);
        if (GeometryUtility.TestPlanesAABB(planes, player.GetComponent<CapsuleCollider>().bounds))
        {
            scoreManager.setPlayerIsOnCamera(true);
        }
        else
        {
            scoreManager.setPlayerIsOnCamera(false);
        }
    }
}
