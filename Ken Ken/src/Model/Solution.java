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
public class Solution {
    private NodekenKen matrix[][];
    private boolean failure = false;
    private int shapeType;
    private int[] permutation;
     public Solution(){
         failure = true;
     }

    public NodekenKen[][] getMatrix() {
        return matrix;

    private boolean podeByShape(){
        //Validar por tipo de forma que no se puedan repetir 2 numeros en la permutacion
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
        for(int i = 0; i < pastMatrix.length; i++){
            for(int j = 0; j < pastMatrix[i].length; j++){
                NodekenKen copiedNode = new NodekenKen();
            }
        }
    }
    
    
    public Solution(NodekenKen pMatrix[][]){
        matrix = pMatrix;
    }
     
    public Solution(Solution solution, int pShapeType, int[] section, int[] pPermutation){
        copyMatrix(solution.getMatrix());
        shapeType = pShapeType;
        permutation = pPermutation;
    }
     
    public boolean isFailure(){
        return failure;
    }
    
    public boolean isPromising(){
        podeByShape();
        podeByRowColumn();
        return true;
    }
}
