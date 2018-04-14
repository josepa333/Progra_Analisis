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
    private int row;
    private int column;

    public NodeSolution(int pIdShape, char pOperator,int pResult,int pRow, int pColumn){
        next=previous=null;
        idShape = pIdShape;
        operator = pOperator;
        result = pResult;
        actualResult = 0;
        row = pRow;
        column = pColumn;
    }
    
    public NodeSolution(){
        next=previous=null;
    }
    
    public void addAdjacentNodes(NodeSolution pNext,NodeSolution pPrevious){
        next=pNext;
        previous=pPrevious;
    }

    public NodeSolution getNext() {
        return next;
    }

    public void setNext(NodeSolution next) {
        this.next = next;
    }

    public NodeSolution getPrevious() {
        return previous;
    }

    public void setPrevious(NodeSolution previous) {
        this.previous = previous;
    }

    public int getValue() {
        return value;
    }

    public void setValue(int value) {
        this.value = value;
    }

    public int getIdShape() {
        return idShape;
    }

    public void setIdShape(int idShape) {
        this.idShape = idShape;
    }

    public char getOperator() {
        return operator;
    }

    public void setOperator(char operator) {
        this.operator = operator;
    }

    public int getResult() {
        return result;
    }

    public void setResult(int result) {
        this.result = result;
    }

    public int getActualResult() {
        return actualResult;
    }

    public void setActualResult(int actualResult) {
        this.actualResult = actualResult;
    }

    public int getRow() {
        return row;
    }

    public void setRow(int row) {
        this.row = row;
    }

    public int getColumn() {
        return column;
    }

    public void setColumn(int column) {
        this.column = column;
    }
    
    
    
}

