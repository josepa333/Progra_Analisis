/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Model;

import java.util.ArrayList;


/**
 *
 * @author jose pablo
 */
public class Solution {
    private static ArrayList<ArrayList<int[]>> shapes;
    private NodekenKen matrix[][];
    private boolean failure = false;
    private int shapeType;
    private int[] permutation;
    private int[] beginOfSection;
    
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
                 return true;
             }
         }
         return false;
    }
     
    public boolean checkColumn(int col,int value){
         for(int i = 0; i <  matrix.length; i++){
             if(matrix[i][col].getValue() == value ){
                 return true;
             }
         }
         return false;
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
            if (checkRow(x,value) || checkColumn(y,value)) {
                    System.out.println("Se repite numero en fila o columna");
                    return false;
            }
            node = node.getNext();
            i++;
        }
        return true;
    }
    
    private void addPermutation(){
        NodekenKen node = matrix[beginOfSection[0]][beginOfSection[1]];
        int i = 0;
        while(i < permutation.length){
            node.setValue(permutation[i]);
            node = node.getNext();
            i++;
        }
    }
    
    private void cloneMatrix(NodekenKen[][] pMatrix){
        matrix = new NodekenKen[pMatrix.length][pMatrix.length];
        NodekenKen node1;
        NodekenKen node2;
        NodekenKen temp;
        for(int shape = 0; shape < shapes.size(); shape++){
            for(int section = 0; section < shapes.get(shape).size(); section++){
                int[] start = shapes.get(shape).get(section);
                node1 = pMatrix[start[0]][start[1]];
                node2 = new NodekenKen(node1.getValue(), node1.getCounter(), node1.getCoordinates()); 
                matrix[node1.getCoordinates()[0]][node1.getCoordinates()[1]] = node2;
                node1 = node1.getNext();
                if(node1 != null){
                    temp =  new NodekenKen(node1.getValue(), node1.getCounter(), node1.getCoordinates());
                    node2.setNext( temp );
                    node2 = temp;
                    matrix[node1.getCoordinates()[0]][node1.getCoordinates()[1]] = node2;
                    node1 = node1.getNext();           
                    if(node1 != null){
                        temp =  new NodekenKen(node1.getValue(), node1.getCounter(), node1.getCoordinates());
                        node2.setNext( temp );
                        node2 = temp;
                        matrix[node1.getCoordinates()[0]][node1.getCoordinates()[1]] = node2;
                        node1 = node1.getNext();   
                        if(node1 != null){
                            temp =  new NodekenKen(node1.getValue(), node1.getCounter(), node1.getCoordinates());
                            node2.setNext( node1 );
                            node2 = temp;
                            matrix[node1.getCoordinates()[0]][node1.getCoordinates()[1]] = node2;
                        }
                    }
                }
            }
        }
    }
    
    public Solution(){
        failure = true;
    }
    
    public Solution(NodekenKen pMatrix[][], ArrayList<ArrayList<int[]>> pShapes){
        matrix = pMatrix;
        shapes = pShapes;
    }
     
    public Solution(Solution solution, int pShapeType, int[] pBeginOfSection, int[] pPermutation){
        cloneMatrix(solution.getMatrix());
        System.out.println("MatrixSolution");
        for(int i = 0; i < matrix.length; i++){
            for(int j = 0; j < matrix[i].length; j++){
                System.out.print(matrix[i][j].getValue() + "\t");
            }
            System.out.println();
        }
        shapeType = pShapeType;
        beginOfSection = pBeginOfSection;
        permutation = pPermutation;
    }
    
    public boolean isPromising(){
        if(podeByShape()){
            if(podeByRowColumn()){
                addPermutation();
                return true;
            }
            else{
                return false;
            }
        }
        return false;
    }
     
    public boolean isFailure(){
        return failure;
    }

    public NodekenKen[][] getMatrix() {
        return matrix;
    }
}
