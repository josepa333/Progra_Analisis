/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Model;


import java.util.ArrayList;

import java.util.HashMap;


/**
 *
 * @author jose pablo
 */
public class Solution {
    private NodekenKen matrix[][];
    private boolean failure = false;
    private int shapeType;
    private int[] permutation;
    private int[] beginOfSection;
    private HashMap< Integer, HashMap<Integer,Byte>> rows;
    private HashMap< Integer, HashMap<Integer,Byte>> cols;//Parametro del constructor
    
    private boolean podeBySquare(){
        if(permutation[0] == permutation[1]){
            return false;
        }
        if(permutation[2] == permutation[3]){
            return false;
        }
        if(permutation[0] == permutation[2]){
            return false;
        }
        if(permutation[1] == permutation[3]){
            return false;
        }
        return true;
    }
    
    private boolean podeByL(){
        if(permutation[0] == permutation[1]){
            return false;
        }
        if(permutation[1] == permutation[2]){
            return false;
        }
        if(permutation[0] == permutation[2]){
            return false;
        }
        if(permutation[2] == permutation[3]){
            return false;
        }
        return true;
    }
    
    private boolean podeByS(){
        if(permutation[0] == permutation[1]){
            return false;
        }
        if(permutation[2] == permutation[3]){
            return false;
        }
        if(permutation[0] == permutation[2]){
            return false;
        }
        return true;
    }
    
    private boolean podeByT(){
        if(permutation[0] == permutation[2]){
            return false;
        }
        if(permutation[1] == permutation[2]){
            return false;
        }
        if(permutation[2] == permutation[3]){
            return false;
        }
        if(permutation[1] == permutation[3]){
            return false;
        }
        return true;
    }
    
    private boolean podeByStick(){
        if(permutation[0] == permutation[1]){
            return false;
        }
        if(permutation[0] == permutation[2]){
            return false;
        }
        if(permutation[0] == permutation[3]){
            return false;
        }
        if(permutation[1] == permutation[2]){
            return false;
        }
        if(permutation[1] == permutation[3]){
            return false;
        }
        if(permutation[2] == permutation[3]){
            return false;
        }
        return true;
    }
    
    private boolean podeByShape(){
        boolean promising = true;
        switch(shapeType){
            case 2:
                promising = podeBySquare();
                break;
            case 3:
                promising = podeByL();
                break;
            case 4:
                promising = podeByS();
                break;
            case 5:
                promising = podeByT();
                break;
            case 6:
                promising = podeByStick();
                break;
            default:
                break;
        }
        return promising;

    }
    
    private boolean podeByRowColumn(){
        if(checkRow() == false || checkColumn() == false){
            return false;
        }
        return true;
    }
    
    private boolean checkRow(){
        return true;

    }
    
    private boolean checkColumn(){
        return true;
    }
    

    //It copies the previous matrix that was updated with a new permutation
    //Revisar
    private void copyMatrix(NodekenKen[][] pastMatrix){
        //Collections.copy(matrix, pastMatrix);
    }
        
    private void addPermutation(int[] permutation){
        NodekenKen node = matrix[beginOfSection[0]][beginOfSection[1]];
        int i = 0;
        byte a = Byte.parseByte("s");
        while(node != null){
            if ((rows.get(node.getCoordinates()[0]).get(permutation[i]) != null) &&
                    (cols.get(node.getCoordinates()[1]).get(permutation[i]) != null)){
                    return;
            }
            else{
                node.setValue(permutation[i]);
                rows.get(node.getCoordinates()[0]).put(permutation[i],a);
                cols.get(node.getCoordinates()[1]).put(permutation[i], a);
            }
            node = node.getNext();
            i++;
        }
        return;
    }
    
    // Para que se modifiquen dentro de cada uno
    
    public Solution(){
        failure = true;
    }
    
    public Solution(NodekenKen pMatrix[][]){
        matrix = pMatrix;
    }
     
    public Solution(Solution solution, int pShapeType, int[] pBeginOfSection, int[] pPermutation){
        matrix = solution.getMatrix().clone();
        shapeType = pShapeType;
        beginOfSection = pBeginOfSection;
        permutation = pPermutation;
    }
     
    public boolean isFailure(){
        return failure;
    }
    
    public boolean isPromising(){

       // podeByShape();
        podeByRowColumn();

        if(podeByShape()){
            return podeByRowColumn();
        }
        return false;
    }

    public NodekenKen[][] getMatrix() {
        return matrix;
    }
}
