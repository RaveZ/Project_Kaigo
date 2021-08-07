using UnityEngine;

namespace Z.UnityHelper.Extension
{
	public static class RendererExtensions
	{
		public static bool IsVisibleFrom (this Bounds bounds, Camera camera)
		{
			Plane [] planes = GeometryUtility.CalculateFrustumPlanes (camera);
			return GeometryUtility.TestPlanesAABB (planes, bounds);
		}

		public static bool IsVisibleFrom (this Renderer renderer, Camera camera)
		{
			Plane [] planes = GeometryUtility.CalculateFrustumPlanes (camera);
			return GeometryUtility.TestPlanesAABB (planes, renderer.bounds);
		}

		public static bool IsRendered (this Camera camera, Renderer renderer)
		{
			Plane [] planes = GeometryUtility.CalculateFrustumPlanes (camera);
			return GeometryUtility.TestPlanesAABB (planes, renderer.bounds);
		}

		public static bool IsRendered (this Camera camera, Bounds bounds)
		{
			Plane [] planes = GeometryUtility.CalculateFrustumPlanes (camera);
			return GeometryUtility.TestPlanesAABB (planes, bounds);
		}
	}
}
