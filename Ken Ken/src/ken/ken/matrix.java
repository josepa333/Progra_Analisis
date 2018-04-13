/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ken.ken;

/**
 *
 * @author jose pablo
 */
public class matrix {
     nodeMatrix matrix[][];
     int counter;
     char[] operations;
     int size;
     
     public  matrix(int pSize){
         size = pSize;
         matrix = new nodeMatrix[size][size];
         createNodes();
         counter = 0;
         operations = new char[] {'+','-','*','/','%','^'};
         fillMatrix();
     }
     
     private void createNodes(){
         for(int i=0; i < size;i++){
             for(int j = 0 ; j < size ; j++ ){
                 matrix[i][j] = new nodeMatrix();
             }
         }
     }
     
     public void addNode(int row, int col, int pValue){
         matrix[row][col].value = pValue;
     }
     
     public void fillMatrix(){
         
         for(int i=0; i < size;i++){
             for(int j = 0 ; j < size ; j++ ){//Cambiar a que maximo haga la cantidad de formas por recursion
                 if(matrix[i][j].check ==  true){ //get
                     boolean flag = false;
                     while(flag == false){
                         int rand = (int) (Math.random() * 3);
                         switch (rand) {
                             case 0:
                                 flag = createSquare(i,j);
                                 break;
                             case 1:
                                 flag = createTwoPower(i,j);
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
         if(col != size - 1 &&  matrix[row][col+1].check == true){
             
             int operation = (int) (Math.random() * 5);
             int result = (int) (Math.random() * 1000) + 5;
             
             matrix[row][col] = new nodeMatrix(counter, operations[operation], result);//create the four nodes
             matrix[row][col+1] = new nodeMatrix(counter, operations[operation], result);
             matrix[row][col].check = matrix[row][col+1].check = false; //The will have a operation asigned
             counter++;
             return true;
         }
         if(row != size - 1 &&  matrix[row+1][col].check == true){
             
             int operation = (int) (Math.random() * 5);
             int result = (int) (Math.random() * 1000) + 5;
             
             matrix[row][col] = new nodeMatrix(counter, operations[operation], result);//create the four nodes
             matrix[row+1][col] = new nodeMatrix(counter, operations[operation], result);
             matrix[row][col].check = matrix[row+1][col].check = false; //The will have a operation asigned
             counter++;
             return true;
         }
         return false;
     }
             
     private boolean createSquare(int row, int col){
         if(row == size-1 || col == size-1){
             return false;
         }
         if(matrix[row][col+1].check == true && matrix[row+1][col].check == true &&
                 matrix[row+1][col+1].check ==true){
             
             int operation = (int) (Math.random() * 3);
             int result = (int) (Math.random() * 1000) + 5;

             matrix[row][col] = new nodeMatrix(counter, operations[operation], result);//create the four nodes
             matrix[row][col+1] = new nodeMatrix(counter, operations[operation], result);
             matrix[row+1][col] = new nodeMatrix(counter, operations[operation], result);
             matrix[row+1][col+1] = new nodeMatrix(counter, operations[operation], result);
             
             matrix[row][col].check = matrix[row][col+1].check = matrix[row+1][col].check  = matrix[row+1][col+1].check = false; //The will have a operation asigned
             counter++;
             return true;//Shape created
         }
         return false;
     }
     
      private boolean createTwoPower(int row, int col){
          
          int result = (int) (Math.random() *5)+1;
          matrix[row][col] = new nodeMatrix(counter, operations[5], result);
          matrix[row][col].check = false;
          counter++;
          return true;
      }
     
}
