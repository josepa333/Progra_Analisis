/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Model;

import java.util.ArrayList;
import java.util.Collections;
import java.util.HashMap;

//kenkenTemplate.xml; 
/**
 *
 * @author jose pablo
 */
public class KenKen {
     private ArrayList<ArrayList<int[]>> shapes;
     private ArrayList<int[]> oneNode;
     private ArrayList<int[]> twoNodes;
     private ArrayList<int[]> fourNodes;
     private HashMap<Integer,ArrayList<int[]>> allPermutations;
     
     private NodekenKen matrix[][];
     private int matrixOfValues[][];
     private int counter;
     private char[] operations;
     private int size;
     
     private int[] rangeOfValues;//Borra cuando ya se tengan las plantillas. 
     
     public  KenKen(int pSize){
         size = pSize;
         matrix = new NodekenKen[size][size];
         matrixOfValues = new int[size][size];
         counter = 0;
         operations = new char[] {'+','-','*','/','%','^'};
         rangeOfValues = new int[] {1,2,3,4,5,6,7,8,9,0,-1,-2,-3,-4,-5,-6,-7,-8,-9};
         shapes = new ArrayList<>();
         oneNode = new ArrayList<>();
         twoNodes = new ArrayList<>();  
         fourNodes = new ArrayList<>();
         allPermutations = new HashMap<>();
         
         createNodes();
     }
     
     private void createNodes(){
         for(int i=0; i < size;i++){
             for(int j = 0 ; j < size ; j++ ){
                 matrix[i][j] = new NodekenKen();
             }
         }
     }
      
     public void changeMatrix(int pSize){
         size = pSize;
         fillMatrixValues();
         fillMatrix();
     }
     
     private void fillMatrixValues(){  //Make it right 
         int range = 0;
         for(int i=0; i < size; i++){
             for(int j = 0 ; j < size; j++ ){
                 int value = 0;
                 boolean flag = false;
                 while(flag == false){
                     value = rangeOfValues[range];
                     flag = checkColumn(j,value)   & checkRow(i,value) ;
                     range++;
                 }
                 range = 0;
                 matrixOfValues[i][j] = value;
                 System.out.print(Integer.toString( matrixOfValues[i][j] ));
             }
             System.out.println(" ");
         }
     }
     
     private boolean checkColumn(int col,int value){
         for(int i = 0; i < size; i++){
             if(matrixOfValues[i][col] == value ){
                 return false;
             }
         }
         return true;
     }
     
     private boolean checkRow(int row,int value){
         for(int i = 0; i < size; i++){
             if(matrixOfValues[row][i] == value ){
                 return false;
             }
         }
         return true;
     }
     
     private void fillMatrix(){
         
         for(int i=0; i < size;i++){
             for(int j = 0 ; j < size ; j++ ){//Cambiar a que maximo haga la cantidad de formas por recursion
                 if(matrix[i][j].isCheck() ==  true){ 
                     boolean flag = false;
                     while(flag == false){
                         int rand = (int) (Math.random() * 9);
                         switch (rand) {
                             case 0:
                                 flag = createSquare(i,j);
                                 break;
                            case 1:
                                flag = createPowerOfTwo(i,j);
                                break;
                             case 2:
                                 flag = createTwoNodes(i,j);
                                 break;
                             case 3:
                                 flag = createS(i,j);
                                 break;
                             case 4:
                                 flag = createT(i,j);
                                 break;
                             case 5:
                                 flag = createLongVerticalStick(i,j);
                                 break;
                             case 6:
                                 flag = createLongHorizontalStick(i,j);
                                 break;
                             case 7:
                                 flag = createVerticalL(i,j);
                                 break;
                             case 8:
                                 flag = createHorizontalL(i,j);
                                 break;
                             default:
                                 break;
                         }
                    }
                 }
             }
         }
         shapes.add(oneNode);
         shapes.add(twoNodes);
         shapes.add(fourNodes);
     }
     
     //Shapes
     private boolean createTwoNodes(int row, int col){
         if(row == size-1 && col == size-1 ){
             return false;
         }
 
         if(col != size - 1 &&  matrix[row][col+1].isCheck() == true){
             
             int operation = (int) (Math.random() * 5);
             int result= determineResultForTwoNodes(counter,operation,matrixOfValues[row][col] , matrixOfValues[row][col+1] );
             //Permutations
             
             int r =  (int) (Math.random() * 255) + 1;
             int g =  (int) (Math.random() * 255) + 1;
             int b =  (int) (Math.random() * 255) + 1;
             
             matrix[row][col] = new NodekenKen(counter, operations[operation], result, new int[] {r,g,b},row,col );//create the four nodes
             matrix[row][col+1] = new NodekenKen(counter, ' ', 0, new int[] {r,g,b}, row, col+1);
             
             matrix[row][col].setCheck(false);
             matrix[row][col+1].setCheck(false);  //The will have a operation asigned
             
             //Next and add to array shapes 
             matrix[row][col].setNext(matrix[row][col+1]);
             twoNodes.add(new int[]{row,col});
             counter++;
             return true;
         }
         if(row != size - 1 &&  matrix[row+1][col].isCheck() == true){
             
             int operation = (int) (Math.random() * 5);
             int result = determineResultForTwoNodes(counter,operation,matrixOfValues[row][col] , matrixOfValues[row+1][col] );
             int r =  (int) (Math.random() * 255) + 1;
             int g =  (int) (Math.random() * 255) + 1;
             int b =  (int) (Math.random() * 255) + 1;
            
             matrix[row][col] = new NodekenKen(counter, operations[operation], result, new int[] {r,g,b}, row,col);//create the four nodes
             matrix[row+1][col] = new NodekenKen(counter, ' ', 0, new int[] {r,g,b}, row+1, col);
             matrix[row][col].setCheck(false);
             matrix[row+1][col].setCheck(false);
             twoNodes.add(new int[]{row,col});
             counter++;
             return true;
         }
         return false;
     }
             
     private boolean createSquare(int row, int col){
         if(row == size-1 || col == size-1){
             return false;
         }
         if(matrix[row][col+1].isCheck() == true && matrix[row+1][col].isCheck() == true &&
                 matrix[row+1][col+1].isCheck() ==true){
             
             int operation = (int) (Math.random() * 4);//+-*/  
             
             int result = determineResultForValuesSquare(counter,operation, matrixOfValues[row][col],
                     matrixOfValues[row][col+1],matrixOfValues[row+1][col],matrixOfValues[row+1][col+1]);
             
             int r =  (int) (Math.random() * 255) + 1;
             int g =  (int) (Math.random() * 255) + 1;
             int b =  (int) (Math.random() * 255) + 1;
 
             matrix[row][col] = new NodekenKen(counter, operations[operation], result, new int[] {r,g,b},row,col);//create the four nodes
             matrix[row][col+1] = new NodekenKen(counter, ' ', 0, new int[] {r,g,b},row,col+1);
             matrix[row+1][col] = new NodekenKen(counter,  ' ', 0, new int[] {r,g,b},row+1,col);
             matrix[row+1][col+1] = new NodekenKen(counter, ' ', 0, new int[] {r,g,b}, row+1,col+1);
             
             matrix[row][col].setCheck(false);
             matrix[row][col+1].setCheck(false);
             matrix[row+1][col].setCheck(false);
             matrix[row+1][col+1].setCheck(false); //The will have a operation asigned
             
             //Next and shapes
             matrix[row][col].setNext(matrix[row][col+1]);
             matrix[row][col+1].setNext(matrix[row+1][col]);
             matrix[row+1][col].setNext(matrix[row+1][col+1]);
             
             fourNodes.add(new int[]{row,col});
             counter++;
             return true;//Shape created
         }
         return false;
     }
     
     private boolean createPowerOfTwo(int row, int col){
          
          int result = (int) Math.pow(2, matrixOfValues[row][col]);
          allPermutations.put(counter, powerOfTwo(result));
          
          int r =  (int) (Math.random() * 255) + 1;
          int g =  (int) (Math.random() * 255) + 1;
          int b =  (int) (Math.random() * 255) + 1;
          
          matrix[row][col] = new NodekenKen(counter, operations[5], result, new int[] {r,g,b}, row, col);
          matrix[row][col].setCheck(false);
          oneNode.add(new int[]{row,col});
          counter++;
          return true;
      }
     
     private boolean createS(int row, int col){
         if(row == size-1 || col == size-1 || col == 0){
             return false;
         }         
         if(matrix[row][col+1].isCheck() == true && matrix[row+1][col].isCheck() == true
                  && matrix[row+1][col-1].isCheck() ==true){
             
             int operation = (int) (Math.random() * 4);//+-*/ 
             
             int result = determineResultForValuesSquare(counter,operation,matrixOfValues[row][col],
                     matrixOfValues[row][col+1],matrixOfValues[row+1][col],matrixOfValues[row+1][col-1]);
             
             int r =  (int) (Math.random() * 255) + 1;
             int g =  (int) (Math.random() * 255) + 1;
             int b =  (int) (Math.random() * 255) + 1;
 
             matrix[row][col] = new NodekenKen(counter, operations[operation], result, new int[] {r,g,b}, row, col);//create the four nodes
             matrix[row][col+1] = new NodekenKen(counter, ' ', 0, new int[] {r,g,b}, row, col+1);
             matrix[row+1][col] = new NodekenKen(counter,  ' ', 0, new int[] {r,g,b}, row+1, col);
             matrix[row+1][col-1] = new NodekenKen(counter, ' ', 0, new int[] {r,g,b}, row+1, col-1);
             
             matrix[row][col].setCheck(false);
             matrix[row][col+1].setCheck(false);
             matrix[row+1][col].setCheck(false);
             matrix[row+1][col-1].setCheck(false); //The will have a operation asigned
             
             //Next and shapes
             matrix[row][col].setNext(matrix[row][col+1]);
             matrix[row][col+1].setNext(matrix[row+1][col]);
             matrix[row+1][col].setNext(matrix[row+1][col-1]);
             
             fourNodes.add(new int[]{row,col});
             counter++;
             return true;//Shape created
         }
         return false;
     }
     
     private boolean createT(int row, int col){
         if(row == size-1 || col == size-1 || col == 0){
             return false;
         }        
         
         if(matrix[row+1][col+1].isCheck() == true && matrix[row+1][col].isCheck() == true
                  && matrix[row+1][col-1].isCheck() ==true){
             
             int operation = (int) (Math.random() * 4);//+-*/ 
             int result = determineResultForValuesSquare(counter, operation, matrixOfValues[row][col],
                     matrixOfValues[row+1][col+1],matrixOfValues[row+1][col],matrixOfValues[row+1][col-1]);
             
             int r =  (int) (Math.random() * 255) + 1;
             int g =  (int) (Math.random() * 255) + 1;
             int b =  (int) (Math.random() * 255) + 1;
 
             matrix[row][col] = new NodekenKen(counter, operations[operation], result, new int[] {r,g,b}, row, col);//create the four nodes
             matrix[row+1][col+1] = new NodekenKen(counter, ' ', 0, new int[] {r,g,b}, row+1, col+1);
             matrix[row+1][col] = new NodekenKen(counter,  ' ', 0, new int[] {r,g,b}, row+1, col);
             matrix[row+1][col-1] = new NodekenKen(counter, ' ', 0, new int[] {r,g,b}, row+1, col-1);
             
             matrix[row][col].setCheck(false);
             matrix[row+1][col+1].setCheck(false);
             matrix[row+1][col].setCheck(false);
             matrix[row+1][col-1].setCheck(false); //The will have a operation asigned
             
             //nex and shapes
             matrix[row][col].setNext(matrix[row+1][col+1]);
             matrix[row+1][col+1].setNext(matrix[row+1][col]);
             matrix[row+1][col].setNext(matrix[row+1][col-1]);
             
             fourNodes.add(new int[]{row,col});
             counter++;
             return true;//Shape created
             
         }
         return false;
     }
     
     private boolean createLongVerticalStick(int row, int col){
         if(row > (size - 4)){
             return false;
         }
         if( matrix[row+1][col].isCheck() == true &&  matrix[row+2][col].isCheck() == true  &&
                 matrix[row+3][col].isCheck() == true ){
             
              int operation = (int) (Math.random() * 4);//+-*/ 
             int result = determineResultForValuesSquare(counter,operation,matrixOfValues[row][col],
                     matrixOfValues[row+1][col],matrixOfValues[row+2][col],matrixOfValues[row+3][col]);
             
             int r =  (int) (Math.random() * 255) + 1;
             int g =  (int) (Math.random() * 255) + 1;
             int b =  (int) (Math.random() * 255) + 1;
 
             matrix[row][col] = new NodekenKen(counter, operations[operation], result, new int[] {r,g,b}, row, col);//create the four nodes
             matrix[row+1][col] = new NodekenKen(counter, ' ', 0, new int[] {r,g,b}, row+1, col);
             matrix[row+2][col] = new NodekenKen(counter,  ' ', 0, new int[] {r,g,b}, row+2, col);
             matrix[row+3][col] = new NodekenKen(counter, ' ', 0, new int[] {r,g,b}, row+3, col);
             
             matrix[row][col].setCheck(false);
             matrix[row+1][col].setCheck(false);
             matrix[row+2][col].setCheck(false);
             matrix[row+3][col].setCheck(false); //The will have a operation asigned
             
             //Next and shaps
             matrix[row][col].setNext(matrix[row+1][col]);
             matrix[row+1][col].setNext(matrix[row+2][col]);
             matrix[row+2][col].setNext(matrix[row+3][col]);
             
             fourNodes.add(new int[]{row,col});
             counter++;
             return true;//Shape created
         }
         return false;
     }
     
     private boolean createLongHorizontalStick(int row, int col){
         
         if(col > (size - 4)){
             return false;
         }
         if( matrix[row][col+1].isCheck() == true &&  matrix[row][col+2].isCheck() == true  &&
                 matrix[row][col+3].isCheck() == true ){
             
             int operation = (int) (Math.random() * 4);//+-*/ 
             int result = determineResultForValuesSquare(counter,operation,matrixOfValues[row][col],
                     matrixOfValues[row][col+1],matrixOfValues[row][col+2],matrixOfValues[row][col+3]);
             
             int r =  (int) (Math.random() * 255) + 1;
             int g =  (int) (Math.random() * 255) + 1;
             int b =  (int) (Math.random() * 255) + 1;
 
             matrix[row][col] = new NodekenKen(counter, operations[operation], result, new int[] {r,g,b}, row, col);//create the four nodes
             matrix[row][col+1] = new NodekenKen(counter, ' ', 0, new int[] {r,g,b}, row, col+1);
             matrix[row][col+2] = new NodekenKen(counter,  ' ', 0, new int[] {r,g,b}, row, col+2);
             matrix[row][col+3] = new NodekenKen(counter, ' ', 0, new int[] {r,g,b}, row, col+3);
             
             matrix[row][col].setCheck(false);
             matrix[row][col+1].setCheck(false);
             matrix[row][col+2].setCheck(false);
             matrix[row][col+3].setCheck(false); //The will have a operation asigned
             
             //Next and hsapes
             matrix[row][col].setNext(matrix[row][col+1]);
             matrix[row][col+1].setNext(matrix[row][col+2]);
             matrix[row][col+2].setNext(matrix[row][col+3]);
             
             fourNodes.add(new int[]{row,col});
             counter++;
             return true;//Shape created
         }
         return false;
     }
     
     private boolean createVerticalL(int row, int col){
         if(row > (size - 3) || col == size -1){
             return false;
         }
         if( matrix[row+1][col].isCheck() == true &&  matrix[row+2][col].isCheck() == true  &&
                 matrix[row+2][col+1].isCheck() == true ){
             
             int operation = (int) (Math.random() * 4);//+-*/ 
             int result = determineResultForValuesSquare(counter,operation,matrixOfValues[row][col],
                     matrixOfValues[row+1][col],matrixOfValues[row+2][col],matrixOfValues[row+2][col+1]);
             
             int r =  (int) (Math.random() * 255) + 1;
             int g =  (int) (Math.random() * 255) + 1;
             int b =  (int) (Math.random() * 255) + 1;
 
             matrix[row][col] = new NodekenKen(counter, operations[operation], result, new int[] {r,g,b}, row, col);//create the four nodes
             matrix[row+1][col] = new NodekenKen(counter, ' ', 0, new int[] {r,g,b}, row+1, col);
             matrix[row+2][col] = new NodekenKen(counter,  ' ', 0, new int[] {r,g,b}, row+2, col);
             matrix[row+2][col+1] = new NodekenKen(counter, ' ', 0, new int[] {r,g,b}, row+2, col+1);
             
             matrix[row][col].setCheck(false);
             matrix[row+1][col].setCheck(false);
             matrix[row+2][col].setCheck(false);
             matrix[row+2][col+1].setCheck(false); //The will have a operation asigned
             
             //Next and shapes
             matrix[row][col].setNext(matrix[row+1][col]);
             matrix[row+1][col].setNext(matrix[row+2][col]);
             matrix[row+2][col].setNext(matrix[row+2][col+1]);
             
             fourNodes.add(new int[]{row,col});
             counter++;
             return true;//Shape created
         }
         return false;
     }
     
     private boolean createHorizontalL(int row, int col){
          if(col > (size - 3) || row == size-1){
             return false;
         }
         if( matrix[row][col+1].isCheck() == true &&  matrix[row][col+2].isCheck() == true  &&
                 matrix[row+1][col+2].isCheck() == true ){
             
             int operation = (int) (Math.random() * 4);//+-*/ 
             int result = determineResultForValuesSquare(counter,operation,matrixOfValues[row][col],
                     matrixOfValues[row][col+1],matrixOfValues[row][col+2],matrixOfValues[row+1][col+2]);
             
             int r =  (int) (Math.random() * 255) + 1;
             int g =  (int) (Math.random() * 255) + 1;
             int b =  (int) (Math.random() * 255) + 1;
 
             matrix[row][col] = new NodekenKen(counter, operations[operation], result, new int[] {r,g,b}, row, col);//create the four nodes
             matrix[row][col+1] = new NodekenKen(counter, ' ', 0, new int[] {r,g,b}, row, col+1);
             matrix[row][col+2] = new NodekenKen(counter,  ' ', 0, new int[] {r,g,b}, row, col+2);
             matrix[row+1][col+2] = new NodekenKen(counter, ' ', 0, new int[] {r,g,b}, row+1, col+2);
             
             matrix[row][col].setCheck(false);
             matrix[row][col+1].setCheck(false);
             matrix[row][col+2].setCheck(false);
             matrix[row+1][col+2].setCheck(false); //The will have a operation asigned
             
             //Next and shapes
             matrix[row][col].setNext(matrix[row][col+1]);
             matrix[row][col+1].setNext(matrix[row][col+2]);
             matrix[row][col+2].setNext(matrix[row+1][col+2]);
             
             fourNodes.add(new int[]{row,col});
             counter++;
             return true;//Shape created
         }
         return false;
     }
     
     //Results
     private int determineResultForTwoNodes(int idShape, int operation, int value1, int value2){
 
         int result = 0;   //{'+','-','*','/','%','^'};
         switch (operation) {
             case 0:
                 result =value1 + value2;
                 //Suma de Richi 
                 break;
             case 1:
                 result =value1 - value2;
                 //Resta de Richi 
                 break;
             case 2:
                 result =value1 * value2;
                 allPermutations.put(idShape, manageFactor2(result));
                 break;
             case 3://  divi 
                 result =value1 / value2;
                 //Division de Richi
                 break;
             case 4:// %
                 result =value1 % value2;
                 allPermutations.put(idShape, module(result));
                 break;
             default:
                 break;
         }
         return result;
     }
     
     private int determineResultForValuesSquare(int idShape,int operation,int value1, int value2, int value3, int value4){// Tomar en cuenta negativos, dependiendo del size del KenKen!!!!! 
         int result = 0;   //{'+','-','*','/','%','^'};
         switch (operation) {
             case 0:
                 result = value1 + value2 + value3 + value4;
                 //Suma de Richi
                 break;
             case 1:
                 result = value1 - value2 - value3 - value4;
                 //Resta de Richi
                 break;
             case 2:
                 result = value1 * value2 * value3 * value4;
                 allPermutations.put(idShape, manageFactor4(result));
                 break;
             case 3: 
                 result = value1 / value2 / value3 / value4;
                 //Division de Richi 
                 break;
             default:
                 break;
         }
         return result;
     }
     
      //Permutations 
      private ArrayList<int[]> module(int result){//IDK yet if it is going to be moved 
          
          ArrayList<int[]> pairs = new ArrayList<>();
          for(int i = 1; i < size ; i++){
              for(int j = 1 ; j < i ; j++ ){
                  if( i%j == result){
                      pairs.add(new int[] {i,j} ); 
                      System.out.println(Integer.toString(i) + " " +Integer.toString(j));
                  }
              }
          }
          return pairs;
      }
      
      private ArrayList<int[]> powerOfTwo(int result){
          ArrayList<int[]> uniqueValue = new ArrayList<>();
          int counter = 0;
          while (result > counter && counter <= size){
              if(Math.pow(2,counter) == result){
                    System.out.println(Integer.toString(counter));
                    uniqueValue.add(new int[counter]);
                    break;
                }
                counter++;
          }
          return uniqueValue;
      }
      
    public ArrayList<Integer> factors(int result){
          ArrayList<Integer> factors = new ArrayList<>();
          int div = 2;
          while (result != 1){
              if(result % div == 0){
                  System.out.println( Integer.toString(div));
                  factors.add(div);
                  result = result / div;
                  div = 2;
                  continue;
              }
              div++;
          }
          factors.add(1);
          factors.add(1);
          return factors;
    }
    
    public ArrayList<int[]> manageFactor2(int result){
        ArrayList<int[]> combinations = new ArrayList<>();
        ArrayList<Integer> factors = factors(result);
        
        int value1 =1;
        int value2 = 1;
        int sizeF = factors.size();
        
        for(int i = 0; i< sizeF +1 ;i++){
            
           for(int j = 0; j < (sizeF/2);j++){
               value1 *=(int) factors.get(j);
           }
           for(int j = sizeF/2; j < sizeF ;j++){
               value2 *= (int) factors.get(j);
           }
           if(value1 <= size && value2 <=size){
               System.out.println(Integer.toString(value1)  + " " +Integer.toString(value2));
               combinations.add(new int[]{value1,value2});
           }
           value1 = 1;
           value2 = 1;
           Collections.rotate(factors, 1);
           
        }
        return combinations;
    }
    
    public  ArrayList<int[]>  manageFactor4(int result){
        ArrayList<int[]> combinations = new ArrayList<>();
        ArrayList<Integer> factors = factors(result);
        
        int value1 =1;
        int value2 = 1;
        int value3 = 1;
        int value4 = 1;
        int sizeF = factors.size();
        
        for(int i = 0; i< sizeF +1 ;i++){
           for(int j = 0; j < (sizeF/4);j++){
               value1 *=(int) factors.get(j);
           }
           for(int j = (sizeF/4); j <(sizeF/4) * 2 ;j++){
               value2 *= (int) factors.get(j);
           }
           for(int j = (sizeF/4) * 2; j < (sizeF/4) * 3;j++){
               value3 *=(int) factors.get(j);
           }
           for(int j = (sizeF/4) * 3; j < sizeF ;j++){
               value4 *= (int) factors.get(j);
           }
           if(value1 <= size && value2 <=size  && value3 <= size && value4 <= size  ){
               System.out.println(Integer.toString(value1)  + " " +Integer.toString(value2) + " " + Integer.toString(value3) 
                       +" "+ Integer.toString(value4) );
               combinations.add(new int[]{value1,value2,value3,value4});
           }
           value1 = 1;
           value2 = 1;
           value3 = 1;
           value4 = 1;
           Collections.rotate(factors, 1);
        }
        return combinations;
    }
      
      private void addition2Cells(ArrayList<int[]> permutations, int minValue, int maxValue){
         int[] permutation = new int[] {minValue, maxValue};
         permutations.add(permutation);
         if(maxValue > 0){
             while(minValue <= maxValue){
                 minValue++;
                 maxValue--;
                 permutation[0] = minValue;
                 permutation[1] = maxValue;
                 permutations.add(permutation);
             }
             //return permutations;
         }
         if(maxValue < 0){
             while(maxValue <= minValue){
                 minValue--;
                 maxValue++;
                 permutation[0] = minValue;
                 permutation[1] = maxValue;
             }
         }
         if(maxValue == 0){
         
         }
      }
      
      //solve

      

      
      //sets and gets 
      public NodekenKen[][] getMatrix() {
          return matrix;
      }

      public void setMatrix(NodekenKen[][] matrix) {
          this.matrix = matrix;
      }

      public int getCounter() {
          return counter;
      }

        public void setCounter(int counter) {
            this.counter = counter;
        }

        public char[] getOperations() {
            return operations;
        }

        public void setOperations(char[] operations) {
            this.operations = operations;
        }

        public int getSize() {
            return size;
        }

        public void setSize(int size) {
            this.size = size;
        }
}
