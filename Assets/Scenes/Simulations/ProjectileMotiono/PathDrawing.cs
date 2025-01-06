using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathDrawing : MonoBehaviour
{
    public int numSeconds = 3;

    private void FixedUpdate()
    {
        // Get Information Panel component
        InformationPanelPM ipComponent = gameObject.GetComponent<InformationPanelPM>();

        // Temporarily override throwawayProjectile
        GameObject oldTempProjectile = ipComponent.throwawayProjectile;

        // Set new throwawayProjectile to invisible one.
        ipComponent.throwawayProjectile = GameObject.Find("pathProjectile");

        // create projectile
        ipComponent.launchButtonListener();

        // Simulate n seconds
        // 1/deltaTime is number of updates p/s
        int numIterations = (int)(this.numSeconds * (1 / Time.fixedDeltaTime));

        // Get path projectile and simulate
        // Name is 'pathProjectile(Clone)' because Unity is weird
        GameObject pathProjectile = GameObject.Find("pathProjectile(Clone)");
        DoProjectileMotion pmComponent = pathProjectile.GetComponent<DoProjectileMotion>();
        pmComponent.Start();

        // Holds points
        List<Vector3> points  = new List<Vector3>();

        // simulation time !!
        for (int i = 0; i < numIterations; i++)
        {
            pmComponent.onUpdate();
            points.Add(pathProjectile.transform.position);
        }

        // Set points on line
        LineRenderer lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPositions(points.ToArray());

        // Clean up
        Destroy(pathProjectile);
        ipComponent.throwawayProjectile = oldTempProjectile;
    }
}
