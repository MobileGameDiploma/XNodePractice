using System;
using System.Threading.Tasks;
using UnityEngine;
using XNode;

public class CardNode : Node
{
    [Input] public Empty enter;
    [Output] public Empty exit;

    public void MoveNext() {
        CardsGraph cardsGraph = graph as CardsGraph;

        if (cardsGraph.current != this) {
            Debug.LogWarning("Node isn't active");
            return;
        }

        NodePort exitPort = GetOutputPort("exit");

        if (!exitPort.IsConnected) {
            Debug.LogWarning("Node isn't connected");
            return;
        }

        CardNode node = exitPort.Connection.node as CardNode;
        node.OnEnter();
    }

    public void OnEnter() {
        CardsGraph cardsGraph = graph as CardsGraph;
        cardsGraph.current = this;
        Execute(cardsGraph);
        MoveNext();
    }

    protected void Execute(CardsGraph cardsGraph)
    {
        int randIndex = UnityEngine.Random.Range(0, cardsGraph.CardsList.Cards.Count);
        CardStats currentcard = cardsGraph.CardsList.Cards[randIndex];
        
        GameObject todelete = Instantiate(cardsGraph.CardsList.Cards[randIndex].cardPrefab, cardsGraph.SpawnPoint);

        WaitForUserInput(cardsGraph, currentcard).Wait();
        Destroy(todelete);
    }

    Task WaitForUserInput(CardsGraph cardsGraph, CardStats card)
    {
        while (!(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)))
        {
            if (Input.GetMouseButtonDown(0))
            {
                cardsGraph.parameterManager.UseCard(card);
            }
            else if (Input.GetMouseButtonDown(1))
            {
                cardsGraph.parameterManager.DiscardCard(card);
            }
        }
        
        return Task.CompletedTask;
    }
    
    // We don't care about the return value of the ports. Just return null to stop the console spam.
    public override object GetValue(NodePort port) {
        return null;
    }

    [Serializable]
    public class Empty { }
}
