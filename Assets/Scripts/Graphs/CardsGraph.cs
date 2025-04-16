using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

[CreateAssetMenu(fileName = "New Cards Graph", menuName = "xNode/Graphs/Cards Graph")]
public class CardsGraph : NodeGraph
{
	public CardNode current;
	public Transform SpawnPoint;
	public CardsList CardsList;
	public ParameterManager parameterManager;
	
	public void Start() {
		
		current.OnEnter();
	}
}