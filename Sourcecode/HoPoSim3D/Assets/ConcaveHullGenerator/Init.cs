﻿using UnityEngine;
using System.Collections.Generic;

namespace ConcaveHull
{
	public class Init : MonoBehaviour
	{

		List<Node> dot_list = new List<Node>(); //Used only for the demo
		Hull hull;

		public string seed;
		public int scaleFactor;
		public int number_of_dots;
		public double concavity;

		void Start()
		{
			hull = new Hull();
			setDots(number_of_dots); //Used only for the demo
			generateHull();
		}

		public void generateHull()
		{
			hull.setConvexHull(dot_list);
			hull.setConcaveHull(concavity, scaleFactor);
		}

		public void setDots(int number_of_dots)
		{
			// This method is only used for the demo!
			System.Random pseudorandom = new System.Random(seed.GetHashCode());
			for (int x = 0; x < number_of_dots; x++)
			{
				dot_list.Add(new Node(pseudorandom.Next(0, 100), pseudorandom.Next(0, 100), x));
			}
			//Delete nodes that share same position
			for (int pivot_position = 0; pivot_position < dot_list.Count; pivot_position++)
			{
				for (int position = 0; position < dot_list.Count; position++)
				{
					if (dot_list[pivot_position].x == dot_list[position].x && dot_list[pivot_position].y == dot_list[position].y
						&& pivot_position != position)
					{
						dot_list.RemoveAt(position);
						position--;
					}
				}
			}
		}

		// Unity demo visualization
		void OnDrawGizmos()
		{
			// Convex hull
			Gizmos.color = Color.yellow;
			for (int i = 0; i < hull.hull_edges.Count; i++)
			{
				Vector2 left = new Vector2((float)hull.hull_edges[i].nodes[0].x, (float)hull.hull_edges[i].nodes[0].y);
				Vector2 right = new Vector2((float)hull.hull_edges[i].nodes[1].x, (float)hull.hull_edges[i].nodes[1].y);
				Gizmos.DrawLine(left, right);
			}

			// Concave hull
			Gizmos.color = Color.blue;
			for (int i = 0; i < hull.hull_concave_edges.Count; i++)
			{
				Vector2 left = new Vector2((float)hull.hull_concave_edges[i].nodes[0].x, (float)hull.hull_concave_edges[i].nodes[0].y);
				Vector2 right = new Vector2((float)hull.hull_concave_edges[i].nodes[1].x, (float)hull.hull_concave_edges[i].nodes[1].y);
				Gizmos.DrawLine(left, right);
			}

			// Dots
			Gizmos.color = Color.red;
			for (int i = 0; i < dot_list.Count; i++)
			{
				Gizmos.DrawSphere(new Vector3((float)dot_list[i].x, (float)dot_list[i].y, 0), 0.5f);
			}
		}
	}

}
