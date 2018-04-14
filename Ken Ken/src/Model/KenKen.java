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
     private int counter;
     private char[] operations;
     private int size;
     
     public  KenKen(int pSize){
         size = pSize;
         matrix = new NodekenKen[size][size];
         createNodes();
         counter = 0;
         operations = new char[] {'+','-','*','/','%','^'};
         fillMatrix();
     }
     
     private void createNodes(){
         for(int i=0; i < size;i++){
             for(int j = 0 ; j < size ; j++ ){
                 matrix[i][j] = new NodekenKen();
             }
         }
     }
      
     public void fillMatrix(){
         
         for(int i=0; i < size;i++){
             for(int j = 0 ; j < size ; j++ ){//Cambiar a que maximo haga la cantidad de formas por recursion
                 if(matrix[i][j].isCheck() ==  true){ //get
                     boolean flag = false;
                     while(flag == false){
                         int rand = (int) (Math.random() * 3);
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
                             default:
                                 break;
                         }
                    }
                 }
             }
         }
     }
     
     private boolean createTwoNodes(int row, int col){
         if(row == size-1 && col == size-1 ){
             return false;
         }
 
         if(col != size - 1 &&  matrix[row][col+1].isCheck() == true){
             
             int operation = (int) (Math.random() * 5);
             int result= determineResultForTwoNodes(operation);
             int r =  (int) (Math.random() * 255) + 1;
             int g =  (int) (Math.random() * 255) + 1;
             int b =  (int) (Math.random() * 255) + 1;
             
             matrix[row][col] = new NodekenKen(counter, operations[operation], result, new int[] {r,g,b});//create the four nodes
             matrix[row][col+1] = new NodekenKen(counter, ' ', 0, new int[] {r,g,b});
             matrix[row][col].setCheck(false);
             matrix[row][col+1].setCheck(false); //The will have a operation asigned
             counter++;
             return true;
         }
         if(row != size - 1 &&  matrix[row+1][col].isCheck() == true){
             
             int operation = (int) (Math.random() * 5);
             int result = determineResultForTwoNodes(operation);
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
             
             int operation = (int) (Math.random() * 3);//+-*/%^
             int result = determineResultForValuesSquare(operation);
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
     
     private int determineResultForTwoNodes(int operation){
 
         int result = 0;   //{'+','-','*','/','%','^'};
         switch (operation) {
             case 0:
                 result = (int) (Math.random() * ( size + (size-1) ) );
                 if(result <  3 ){
                     result =  3;
                 }break;
             case 1:
                 result = (int) (Math.random() * (size));
                 int pow = (int) (Math.random() * 2) + 1;
                 int minus1 = (int) Math.pow( -1, pow);
                 result *= minus1; break;
             case 2:
                 result = (int) (Math.random() * (size * (size-1) ));
                 if(result < 2){
                     result = 2;
                 }   break;
             case 3://  divi 
                 result = (int) (Math.random() * (size)) + 1;
                 break;
             case 4:// %
                 result = (int) (Math.random() * (size-1)) + 1;
                 break;
             default:
                 break;
         }
         return result;
     }
     
     private int determineResultForValuesSquare(int operation){// Tomar en cuenta negativos, dependiendo del size del KenKen!!!!! 
         int result = 0;   //{'+','-','*','/','%','^'};
         switch (operation) {
             case 0:
                 result = (int) (Math.random() * ( (size * 2) + ((size-1)  * 2 ) ));
                 if(result <  6 ){
                     result =  6;
                 }break;
             case 1:
                 result = (int) (Math.random() * (1- (size + ((size-1) * 2) ) )) * -1;
                 int pow = (int) (Math.random() * 2) + 1;
                 int minus1 = (int) Math.pow( -1, pow);
                 result *= minus1;
                 if( result > (size-5) ){
                     result = result * -1;
                 }   break;
             case 2:
                 result = (int) (Math.random() * (size * size * (size-1) *  (size-1) ))  ;
                 if(result < 4){
                     result = 4;
                 }   break;
             default:
                 break;
         }
         return result;
     }
     
      private boolean createPowerOfTwo(int row, int col){
          
          int pow = (int) (Math.random() * size);
          int result = (int) Math.pow(2, pow);
          int r =  (int) (Math.random() * 255) + 1;
          int g =  (int) (Math.random() * 255) + 1;
          int b =  (int) (Math.random() * 255) + 1;
          
          matrix[row][col] = new NodekenKen(counter, operations[5], result, new int[] {r,g,b});
          matrix[row][col].setCheck(false);
          counter++;
          return true;
      }
      
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
