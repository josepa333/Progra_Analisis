/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Model;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.Hashtable;


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
    private HashMap< Integer, ArrayList<Integer>> rows;
    private HashMap< Integer, ArrayList<Integer>> cols;//Parametro del constructor
    
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
    private boolean checkRow(int row,int value){
         for(int i = 0; i < matrix.length; i++){
             if(matrix[row][i].getValue() == value){
                 return false;
             }
         }
         return true;
    }
     
    public boolean checkColumn(int col,int value){
         for(int i = 0; i <  matrix.length; i++){
             if(matrix[i][col].getValue() == value ){
                 return false;
             }
         }
         return true;
    }   
    private boolean podeByRowColumn(){
        
        NodekenKen node = matrix[beginOfSection[0]][beginOfSection[1]];
        int i = 0;
        /*System.out.println("Una");
        
        for (int j = 0; j <  permutation.length; j++) {
            System.out.println(Integer.toString( permutation[i] ));
        }*/
        
        while(i < permutation.length){

            int x = node.getCoordinates()[0];
            int y = node.getCoordinates()[1];
            int value = permutation[i];
            if (checkRow(x,value) && checkColumn(y,value) ) {
                    System.out.println("Se repite numero en fila o columna");
                    return false;
            }
            else{ 
                node.setValue(permutation[i]);
                rows.get(node.getCoordinates()[0]).add(permutation[i]);
                cols.get(node.getCoordinates()[1]).add(permutation[i]);
            }
            node = node.getNext();
            i++;
        }
        return true;
    }
    
    public Solution(){
        failure = true;
    }
    
    public Solution(NodekenKen pMatrix[][]){
        matrix = pMatrix;
        rows = new HashMap<>();
        for(int row = 0; row < matrix.length; row++){
            rows.put(row, new ArrayList<>());
        }
        cols = new HashMap<>();
        for(int col = 0; col < matrix[0].length; col++){
            cols.put(col, new ArrayList<>());
        }
    }
     
    public Solution(Solution solution, int pShapeType, int[] pBeginOfSection, int[] pPermutation){
        matrix = solution.getMatrix().clone();
        rows = new HashMap<>(solution.getRows());
        cols = new HashMap<>(solution.getCols());
        shapeType = pShapeType;
        beginOfSection = pBeginOfSection;
        permutation = pPermutation;
    }
    
    public boolean isPromising(){
        if(podeByShape()){
            return podeByRowColumn();
        }
        return false;
    }
     
    public boolean isFailure(){
        return failure;
    }

    public NodekenKen[][] getMatrix() {
        return matrix;
    }
    
    public HashMap<Integer, ArrayList<Integer>> getRows(){
        return rows;
    }
    
    public HashMap<Integer, ArrayList<Integer>> getCols(){
        return cols;
    }
}
