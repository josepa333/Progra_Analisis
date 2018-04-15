/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Model;

import java.util.ArrayList;

//kenkenTemplate.xml; 
/**
 *
 * @author jose pablo
 */
public class KenKen {
     public static ArrayList<ArrayList<int[]>> shapes;
     private NodekenKen matrix[][];
     private int matrixOfValues[][];
     private int counter;
     private char[] operations;
     private int size;
     private int[] rangeOfValues;
     
     public  KenKen(int pSize){
         size = pSize;
         matrix = new NodekenKen[size][size];
         matrixOfValues = new int[size][size];
         counter = 0;
         operations = new char[] {'+','-','*','/','%','^'};
         rangeOfValues = new int[] {1,2,3,4,5,6,7,8,9,0,-1,-2,-3,-4,-5,-6,-7,-8,-9};
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
     }
     
     //Shapes
     private boolean createTwoNodes(int row, int col){
         if(row == size-1 && col == size-1 ){
             return false;
         }
 
         if(col != size - 1 &&  matrix[row][col+1].isCheck() == true){
             
             int operation = (int) (Math.random() * 5);
             int result= determineResultForTwoNodes(operation,matrixOfValues[row][col] , matrixOfValues[row][col+1] );
             
             int r =  (int) (Math.random() * 255) + 1;
             int g =  (int) (Math.random() * 255) + 1;
             int b =  (int) (Math.random() * 255) + 1;
             
             matrix[row][col] = new NodekenKen(counter, operations[operation], result, new int[] {r,g,b});//create the four nodes
             matrix[row][col+1] = new NodekenKen(counter, ' ', 0, new int[] {r,g,b});
             matrix[row][col].setCheck(false);
             matrix[row][col+1].setCheck(false);  //The will have a operation asigned
             counter++;
             return true;
         }
         if(row != size - 1 &&  matrix[row+1][col].isCheck() == true){
             
             int operation = (int) (Math.random() * 5);
             int result = determineResultForTwoNodes(operation,matrixOfValues[row][col] , matrixOfValues[row+1][col] );
             int r =  (int) (Math.random() * 255) + 1;
             int g =  (int) (Math.random() * 255) + 1;
             int b =  (int) (Math.random() * 255) + 1;
            
             matrix[row][col] = new NodekenKen(counter, operations[operation], result, new int[] {r,g,b});//create the four nodes
             matrix[row+1][col] = new NodekenKen(counter, ' ', 0, new int[] {r,g,b});
             matrix[row][col].setCheck(false);
             matrix[row+1][col].setCheck(false);
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
             
             int result = determineResultForValuesSquare(operation, matrixOfValues[row][col],
                     matrixOfValues[row][col+1],matrixOfValues[row+1][col],matrixOfValues[row+1][col+1]);
             
             int r =  (int) (Math.random() * 255) + 1;
             int g =  (int) (Math.random() * 255) + 1;
             int b =  (int) (Math.random() * 255) + 1;
 
             matrix[row][col] = new NodekenKen(counter, operations[operation], result, new int[] {r,g,b});//create the four nodes
             matrix[row][col+1] = new NodekenKen(counter, ' ', 0, new int[] {r,g,b});
             matrix[row+1][col] = new NodekenKen(counter,  ' ', 0, new int[] {r,g,b});
             matrix[row+1][col+1] = new NodekenKen(counter, ' ', 0, new int[] {r,g,b});
             
             matrix[row][col].setCheck(false);
             matrix[row][col+1].setCheck(false);
             matrix[row+1][col].setCheck(false);
             matrix[row+1][col+1].setCheck(false); //The will have a operation asigned
             counter++;
             return true;//Shape created
         }
         return false;
     }
     
     private boolean createPowerOfTwo(int row, int col){
          
          int result = (int) Math.pow(2, matrixOfValues[row][col]);
          int r =  (int) (Math.random() * 255) + 1;
          int g =  (int) (Math.random() * 255) + 1;
          int b =  (int) (Math.random() * 255) + 1;
          
          matrix[row][col] = new NodekenKen(counter, operations[5], result, new int[] {r,g,b});
          matrix[row][col].setCheck(false);
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
             
             int result = determineResultForValuesSquare(operation,matrixOfValues[row][col],
                     matrixOfValues[row][col+1],matrixOfValues[row+1][col],matrixOfValues[row+1][col-1]);
             
             int r =  (int) (Math.random() * 255) + 1;
             int g =  (int) (Math.random() * 255) + 1;
             int b =  (int) (Math.random() * 255) + 1;
 
             matrix[row][col] = new NodekenKen(counter, operations[operation], result, new int[] {r,g,b});//create the four nodes
             matrix[row][col+1] = new NodekenKen(counter, ' ', 0, new int[] {r,g,b});
             matrix[row+1][col] = new NodekenKen(counter,  ' ', 0, new int[] {r,g,b});
             matrix[row+1][col-1] = new NodekenKen(counter, ' ', 0, new int[] {r,g,b});
             
             matrix[row][col].setCheck(false);
             matrix[row][col+1].setCheck(false);
             matrix[row+1][col].setCheck(false);
             matrix[row+1][col-1].setCheck(false); //The will have a operation asigned
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
             int result = determineResultForValuesSquare(operation,matrixOfValues[row][col],
                     matrixOfValues[row+1][col+1],matrixOfValues[row+1][col],matrixOfValues[row+1][col-1]);
             
             int r =  (int) (Math.random() * 255) + 1;
             int g =  (int) (Math.random() * 255) + 1;
             int b =  (int) (Math.random() * 255) + 1;
 
             matrix[row][col] = new NodekenKen(counter, operations[operation], result, new int[] {r,g,b});//create the four nodes
             matrix[row+1][col+1] = new NodekenKen(counter, ' ', 0, new int[] {r,g,b});
             matrix[row+1][col] = new NodekenKen(counter,  ' ', 0, new int[] {r,g,b});
             matrix[row+1][col-1] = new NodekenKen(counter, ' ', 0, new int[] {r,g,b});
             
             matrix[row][col].setCheck(false);
             matrix[row+1][col+1].setCheck(false);
             matrix[row+1][col].setCheck(false);
             matrix[row+1][col-1].setCheck(false); //The will have a operation asigned
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
             int result = determineResultForValuesSquare(operation,matrixOfValues[row][col],
                     matrixOfValues[row+1][col],matrixOfValues[row+2][col],matrixOfValues[row+3][col]);
             
             int r =  (int) (Math.random() * 255) + 1;
             int g =  (int) (Math.random() * 255) + 1;
             int b =  (int) (Math.random() * 255) + 1;
 
             matrix[row][col] = new NodekenKen(counter, operations[operation], result, new int[] {r,g,b});//create the four nodes
             matrix[row+1][col] = new NodekenKen(counter, ' ', 0, new int[] {r,g,b});
             matrix[row+2][col] = new NodekenKen(counter,  ' ', 0, new int[] {r,g,b});
             matrix[row+3][col] = new NodekenKen(counter, ' ', 0, new int[] {r,g,b});
             
             matrix[row][col].setCheck(false);
             matrix[row+1][col].setCheck(false);
             matrix[row+2][col].setCheck(false);
             matrix[row+3][col].setCheck(false); //The will have a operation asigned
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
             int result = determineResultForValuesSquare(operation,matrixOfValues[row][col],
                     matrixOfValues[row][col+1],matrixOfValues[row][col+2],matrixOfValues[row][col+3]);
             
             int r =  (int) (Math.random() * 255) + 1;
             int g =  (int) (Math.random() * 255) + 1;
             int b =  (int) (Math.random() * 255) + 1;
 
             matrix[row][col] = new NodekenKen(counter, operations[operation], result, new int[] {r,g,b});//create the four nodes
             matrix[row][col+1] = new NodekenKen(counter, ' ', 0, new int[] {r,g,b});
             matrix[row][col+2] = new NodekenKen(counter,  ' ', 0, new int[] {r,g,b});
             matrix[row][col+3] = new NodekenKen(counter, ' ', 0, new int[] {r,g,b});
             
             matrix[row][col].setCheck(false);
             matrix[row][col+1].setCheck(false);
             matrix[row][col+2].setCheck(false);
             matrix[row][col+3].setCheck(false); //The will have a operation asigned
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
             int result = determineResultForValuesSquare(operation,matrixOfValues[row][col],
                     matrixOfValues[row+1][col],matrixOfValues[row+2][col],matrixOfValues[row+2][col+1]);
             
             int r =  (int) (Math.random() * 255) + 1;
             int g =  (int) (Math.random() * 255) + 1;
             int b =  (int) (Math.random() * 255) + 1;
 
             matrix[row][col] = new NodekenKen(counter, operations[operation], result, new int[] {r,g,b});//create the four nodes
             matrix[row+1][col] = new NodekenKen(counter, ' ', 0, new int[] {r,g,b});
             matrix[row+2][col] = new NodekenKen(counter,  ' ', 0, new int[] {r,g,b});
             matrix[row+2][col+1] = new NodekenKen(counter, ' ', 0, new int[] {r,g,b});
             
             matrix[row][col].setCheck(false);
             matrix[row+1][col].setCheck(false);
             matrix[row+2][col].setCheck(false);
             matrix[row+2][col+1].setCheck(false); //The will have a operation asigned
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
             int result = determineResultForValuesSquare(operation,matrixOfValues[row][col],
                     matrixOfValues[row][col+1],matrixOfValues[row][col+2],matrixOfValues[row+1][col+2]);
             
             int r =  (int) (Math.random() * 255) + 1;
             int g =  (int) (Math.random() * 255) + 1;
             int b =  (int) (Math.random() * 255) + 1;
 
             matrix[row][col] = new NodekenKen(counter, operations[operation], result, new int[] {r,g,b});//create the four nodes
             matrix[row][col+1] = new NodekenKen(counter, ' ', 0, new int[] {r,g,b});
             matrix[row][col+2] = new NodekenKen(counter,  ' ', 0, new int[] {r,g,b});
             matrix[row+1][col+2] = new NodekenKen(counter, ' ', 0, new int[] {r,g,b});
             
             matrix[row][col].setCheck(false);
             matrix[row][col+1].setCheck(false);
             matrix[row][col+2].setCheck(false);
             matrix[row+1][col+2].setCheck(false); //The will have a operation asigned
             counter++;
             return true;//Shape created
         }
         return false;
     }
     
     //Results
     private int determineResultForTwoNodes(int operation, int value1, int value2){
 
         int result = 0;   //{'+','-','*','/','%','^'};
         switch (operation) {
             case 0:
                 result =value1 + value2;
                 break;
             case 1:
                 result =value1 - value2;
                 break;
             case 2:
                 result =value1 * value2;
                 break;
             case 3://  divi 
                 result =value1 / value2;
                 break;
             case 4:// %
                 result =value1 % value2;
                 break;
             default:
                 break;
         }
         return result;
     }
     
     private int determineResultForValuesSquare(int operation,int value1, int value2, int value3, int value4){// Tomar en cuenta negativos, dependiendo del size del KenKen!!!!! 
         int result = 0;   //{'+','-','*','/','%','^'};
         switch (operation) {
             case 0:
                 result = value1 + value2 + value3 + value4;
                 break;
             case 1:
                 result = value1 - value2 - value3 - value4;
                 break;
             case 2:
                 result = value1 * value2 * value3 * value4;
                 break;
             case 3: 
                 result = value1 / value2 / value3 / value4;
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
      
      private int powerOfTwo(int result){
          int counter = 0;
          while (result > counter && counter <= size){
              if(Math.pow(2,counter) == result){
                    System.out.println(Integer.toString(counter));
                    return counter;
                }
                counter++;
          }
          return counter;
      }
      
      private ArrayList<int[]> factorization(int result){ //Returns the factors, its up to some procedure else to 
                                                                                         // create the permutations
          ArrayList<int[]> factors = new ArrayList<>();
          int div = 2;
          while (result != 1){
              if(result % div == 0){
                  System.out.println( Integer.toString(div));
                  result = result / div;
                  div = 2;
                  continue;
              }
              div++;
          }
          return factors;
      }  

      private ArrayList<int[]> permutationsAddition(int cells, int sum){
      
      }
      
      private ArrayList<int[]> addition2Cells(ArrayList<int[]> permutations, int minValue, int maxValue){
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
             return permutations;
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
