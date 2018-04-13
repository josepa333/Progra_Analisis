/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ken.ken;

/**
 *
 * @author jose pablo
 */
public class nodeMatrix {
    nodeMatrix next;
    nodeMatrix previous;
    int value;
    boolean check;
    int counter;
    char operator;
    int result;
    
    
    public nodeMatrix(int pCounter, char pOperator,int pResult){
    next=previous=null;
    counter = pCounter;
    operator = pOperator;
    result = pResult;
    check = false;
    }
    
    public nodeMatrix(){
        next=previous=null;
        check = true;
    }
    
    public void addAdjacentNodes(nodeMatrix pNext,nodeMatrix pPrevious){
        next=pNext;
        previous=pPrevious;
    }
}
