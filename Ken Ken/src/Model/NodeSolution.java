/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Model;

/**
 *
 * @author jose pablo
 */
public class NodeSolution {
    private NodeSolution next;
    private NodeSolution previous;
    private int value;
    private int idShape;
    private char operator;
    private int result;
    private int actualResult;

    public NodeSolution(int pIdShape, char pOperator,int pResult){
        next=previous=null;
        idShape = pIdShape;
        operator = pOperator;
        result = pResult;
        actualResult = 0;
    }
    
    public NodeSolution(){
        next=previous=null;
    }
    
    public void addAdjacentNodes(NodeSolution pNext,NodeSolution pPrevious){
        next=pNext;
        previous=pPrevious;
    }
    
}

