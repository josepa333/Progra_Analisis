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
    private int value;
    private boolean check;
    private int counter;
    private char operator;
    private int result;
    private int RGB[];
    private int coordinates[];


    public NodekenKen(int pCounter, char pOperator,int pResult, int pRGB[],int row, int col){
    next=null;
    counter = pCounter;
    operator = pOperator;
    result = pResult;
    check = false;
    RGB = pRGB;
    value = -10;
    coordinates = new int[]{row,col};
    }
    
    public NodekenKen(){
        next=null;
        check = true;
    }
    
    public void addAdjacentNodes(NodekenKen pNext){
        next=pNext;
        
    }

    public NodekenKen getNext() {
        return next;
    }

    public void setNext(NodekenKen next) {
        this.next = next;
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

    public int[] getCoordinates() {
        return coordinates;
    }

    public void setCoordinates(int[] coordinates) {
        this.coordinates = coordinates;
    }
    
}
