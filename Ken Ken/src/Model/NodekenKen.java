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

public class NodekenKen {
    private NodekenKen next;
    private NodekenKen previous;
    private int value;
    private boolean check;
    private int counter;
    private char operator;
    private int result;
    private int RGB[];

    
    public NodekenKen(int pCounter, char pOperator,int pResult, int pRGB[]){
    next=previous=null;
    counter = pCounter;
    operator = pOperator;
    result = pResult;
    check = false;
    RGB = pRGB;
    value = 0;
    }
    
    public NodekenKen(){
        next=previous=null;
        check = true;
    }
    
    public void addAdjacentNodes(NodekenKen pNext,NodekenKen pPrevious){
        next=pNext;
        previous=pPrevious;
    }

    public NodekenKen getNext() {
        return next;
    }

    public void setNext(NodekenKen next) {
        this.next = next;
    }

    public NodekenKen getPrevious() {
        return previous;
    }

    public void setPrevious(NodekenKen previous) {
        this.previous = previous;
    }

    public int getValue() {
        return value;
    }

    public void setValue(int value) {
        this.value = value;
    }

    public boolean isCheck() {
        return check;
    }

    public void setCheck(boolean check) {
        this.check = check;
    }

    public int getCounter() {
        return counter;
    }

    public void setCounter(int counter) {
        this.counter = counter;
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

    public int[] getRGB() {
        return RGB;
    }

    public void setRGB(int[] RGB) {
        this.RGB = RGB;
    }
    
}
