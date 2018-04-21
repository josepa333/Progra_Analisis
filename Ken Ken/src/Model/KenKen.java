/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Model;


import java.util.ArrayList;
import java.util.HashMap;
import java.util.Iterator;
import java.util.Map;

/**
 *
 * @author jose pablo
 */
public class KenKen {
     private ArrayList<ArrayList<int[]>> shapes;
     private ArrayList<int[]> sections;
     private ArrayList<int[]> oneNode;
     private ArrayList<int[]> twoNodes;
     private ArrayList<int[]> square;
     private ArrayList<int[]> shapesL;
     private ArrayList<int[]> shapesS;
     private ArrayList<int[]> shapesT;
     private ArrayList<int[]> shapesStick;
     private HashMap<Integer,ArrayList<int[]>> allPermutations;
     private NodekenKen matrix[][];
     
     private int counter;
     private char[] operations;
     private int size;
     
     //Matrix values  
     private int matrixOfValues[][];
     private boolean doneValues;
      private int[] rangeOfValues;
    
     
     public  KenKen(int pSize){
         size = pSize;
         counter = 0;
         matrix = new NodekenKen[size][size];
         matrixOfValues = new int[size][size];
         operations = new char[] {'+','-','*','/','%','^'};
         rangeOfValues = new int[] {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18};
         shapes = new ArrayList<>();
         sections = new ArrayList<>();
         oneNode = new ArrayList<>();
         twoNodes = new ArrayList<>();  
         square = new ArrayList<>();
         shapesL = new ArrayList<>();
         shapesS = new ArrayList<>();
         shapesT = new ArrayList<>();
         shapesStick = new ArrayList<>();
         
         allPermutations = new HashMap<>();
         doneValues = false;
         createNodes();
     }
     
    public Solution solveKenKen(){
        Solution solution = new Solution(matrix);
        return backTracking(solution, 0);
    } 
     
    private Solution backTracking(Solution solution, int sectionId){
        if(sectionId == sections.size()){
            return solution;
        }
        
        int[] sectionInfo = sections.get(sectionId);
        NodekenKen node = matrix[sectionInfo[0]][sectionInfo[1]];
        ArrayList<int[]> permutations = allPermutations.get(node.getCounter());
        for(int k = 0; k < permutations.size(); k++){
            
            Solution child = new Solution(solution, sectionInfo[2], sectionInfo, permutations.get(k) );
            if(child.isPromising()){
                sectionId = sectionId +1;
                Solution result = backTracking(child, sectionId);
                if(result.isFailure() == false){
                    return result;
                } 
            }
        }
        return new Solution();
    }
 
     private void createNodes(){
         for(int i=0; i < size;i++){
             for(int j = 0 ; j < size ; j++ ){
                 matrix[i][j] = new NodekenKen(new int[]{i,j});
             }
         }
     }
      
     public void changeMatrix(int pSize){
         size = pSize;
         fillMatrixValues();
         System.out.println("Fill done");
         setValues();
         System.out.println("values done");
         fillMatrix();
         System.out.println("fill Big done");
     }
     
    public void setValues(){
        int i,j;
        if( allDone() == true){
            print();
            doneValues = true;
        }
        else{
            i = j = 0;
            for (int y = 0; y < size ; y++) {
                for (int x = 0; x < size;x++) {
                    if(matrixOfValues[y][x] == -10){
                        i = y;
                        j = x;
                        break;
                    }
                }
            }
            int value;
            for (int k = 0; k < size; k++) {
                value = rangeOfValues[k];
                if(checkRow(i,value) && checkColumn(j,value)){
                    matrixOfValues[i][j] = value;
                    setValues();
                }
            }
            if(doneValues == false){
                matrixOfValues[i][j] = -10;
            }
        }
    }
    
    public void fillMatrixValues(){
        for(int i = 0; i< size;i++){
            for(int j = 0 ; j< size; j++){
                matrixOfValues[i][j]= -10;
            }
        }
    }
    
    private boolean allDone(){
        for (int i = 0; i <size; i++) {
            for (int j = 0; j < size; j++) {
                if( matrixOfValues[i][j] == -10){
                    return false;
                }
            }
        }
        return true;
    }

    public void print(){
        for(int i = 0; i< size;i++){
            for(int j = 0 ; j<size; j++){
                System.out.print(Integer.toString(matrixOfValues[i][j]) + "\t " );
            }
            System.out.println(" ");
        }
    }

    private boolean checkRow(int row,int value){
         for(int i = 0; i < size; i++){
             if(matrixOfValues[row][i] == value){
                 return false;
             }
         }
         return true;
    }
     
    public boolean checkColumn(int col,int value){
         for(int i = 0; i < size; i++){
             if(matrixOfValues[i][col] == value ){
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
                                flag = createPower(i,j);
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
                                 flag = createPower(i,j);
                                 break;
                         }
                    }
                 }
             }
         }
         if(oneNode.size() > 0){
             shapes.add(oneNode);
         }
         if(twoNodes.size() > 0){
             shapes.add(twoNodes);
         }
         if(square.size() > 0){
             shapes.add(square);
         }
         if(shapesL.size() > 0){
             shapes.add(shapesL);
         }
         if(shapesS.size() > 0){
             shapes.add(shapesS);
         }
         if(shapesT.size() > 0){
             shapes.add(shapesT);
         }
         if(shapesStick.size() > 0){
             shapes.add(shapesStick);
         }
         for(int i = 0; i < shapes.size(); i++){
            for(int j = 0; j < shapes.get(i).size(); j++){
                int[] beginOfSection = shapes.get(i).get(j);
                sections.add(new int[]{beginOfSection[0], beginOfSection[1], i});
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
             if( (matrixOfValues[row][col] == 0 || matrixOfValues[row][col+1] == 0) && (operation== 3 || operation== 2
                     || operation == 4)){
                 operation = 0;
             }
             if( (matrixOfValues[row][col]  < matrixOfValues[row][col+1]) && (operation== 3)){
                 operation = 0;
             }
             int result= determineResultForTwoNodes(counter,operation,matrixOfValues[row][col] , matrixOfValues[row][col+1] );
             //Permutations
             
             int r =  (int) (Math.random() * 255) + 1;
             int g =  (int) (Math.random() * 255) + 1;
             int b =  (int) (Math.random() * 255) + 1;
             
             matrix[row][col].setValues(counter, operations[operation], result, new int[] {r,g,b} );//create the four nodes
             matrix[row][col+1].setValues(counter, ' ', 0, new int[] {r,g,b});
             
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
             if((matrixOfValues[row][col] == 0 || matrixOfValues[row + 1][col] == 0) && (operation== 3 || operation== 2
                     || operation == 4)){
                 operation = 0;
             }
             if( (matrixOfValues[row][col]  < matrixOfValues[row+1][col]) && (operation== 3)){
                 operation = 0;
             }
             
             int result = determineResultForTwoNodes(counter,operation,matrixOfValues[row][col] , matrixOfValues[row+1][col] );
             int r =  (int) (Math.random() * 255) + 1;
             int g =  (int) (Math.random() * 255) + 1;
             int b =  (int) (Math.random() * 255) + 1;
            
             matrix[row][col].setValues(counter, operations[operation], result, new int[] {r,g,b});//create the four nodes
             matrix[row+1][col].setValues(counter, ' ', 0, new int[] {r,g,b});
             
             matrix[row][col].setCheck(false);
             matrix[row+1][col].setCheck(false);
             
             matrix[row][col].setNext(matrix[row+1][col]);
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
             
             if( (matrixOfValues[row][col] == 0|| matrixOfValues[row][col+1] == 0|| 
                     matrixOfValues[row+1][col] == 0 ||matrixOfValues[row+1][col+1] == 0)
                     && (operation== 3 || operation== 2 )){
                 operation = 0;
             }
             
             if( (operation== 3 ) && (matrixOfValues[row][col]/matrixOfValues[row][col+1] < matrixOfValues[row+1][col]) 
                     && (matrixOfValues[row][col]/matrixOfValues[row][col+1] / matrixOfValues[row+1][col] < matrixOfValues[row+1][col+1])){
                 operation = 0;
             }

             int result = determineResultForValuesSquare(counter,operation, matrixOfValues[row][col],
                     matrixOfValues[row][col+1],matrixOfValues[row+1][col],matrixOfValues[row+1][col+1]);
             
             int r =  (int) (Math.random() * 255) + 1;
             int g =  (int) (Math.random() * 255) + 1;
             int b =  (int) (Math.random() * 255) + 1;
 
             matrix[row][col].setValues(counter, operations[operation], result, new int[] {r,g,b});//create the four nodes
             matrix[row][col+1].setValues(counter, ' ', 0, new int[] {r,g,b});
             matrix[row+1][col].setValues(counter,  ' ', 0, new int[] {r,g,b});
             matrix[row+1][col+1].setValues(counter, ' ', 0, new int[] {r,g,b});
             
             matrix[row][col].setCheck(false);
             matrix[row][col+1].setCheck(false);
             matrix[row+1][col].setCheck(false);
             matrix[row+1][col+1].setCheck(false); //The will have a operation asigned
             
             //Next and shapes
             matrix[row][col].setNext(matrix[row][col+1]);
             matrix[row][col+1].setNext(matrix[row+1][col]);
             matrix[row+1][col].setNext(matrix[row+1][col+1]);
             
             square.add(new int[]{row,col});
             counter++;
             return true;//Shape created
         }
         return false;
     }
     
     private boolean createPower(int row, int col){
          
         int result = (int) Math.pow(matrixOfValues[row][col],3);
         allPermutations.put(counter, power(result));
         int r =  (int) (Math.random() * 255) + 1;
         int g =  (int) (Math.random() * 255) + 1;
         int b =  (int) (Math.random() * 255) + 1;

        matrix[row][col].setValues(counter, operations[5], result, new int[] {r,g,b});
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
             //Non 0 * 
             if( (matrixOfValues[row][col]  == 0|| matrixOfValues[row][col+1] == 0 || matrixOfValues[row+1][col ]== 0
                     || matrixOfValues[row+1][col-1] == 0 ) && (operation== 3 || operation== 2 )){
                 operation = 0;
             }
             
             if( (operation== 3 )  && (matrixOfValues[row][col]/matrixOfValues[row][col+1] < matrixOfValues[row+1][col]) 
                     && (matrixOfValues[row][col]/matrixOfValues[row][col+1] / matrixOfValues[row+1][col] < matrixOfValues[row+1][col-1])){
                 operation = 0;
             }

             int result = determineResultForValuesSquare(counter,operation,matrixOfValues[row][col],
                     matrixOfValues[row][col+1],matrixOfValues[row+1][col],matrixOfValues[row+1][col-1]);
             
             int r =  (int) (Math.random() * 255) + 1;
             int g =  (int) (Math.random() * 255) + 1;
             int b =  (int) (Math.random() * 255) + 1;
 
             matrix[row][col].setValues(counter, operations[operation], result, new int[] {r,g,b});//create the four nodes
             matrix[row][col+1].setValues(counter, ' ', 0, new int[] {r,g,b});
             matrix[row+1][col].setValues(counter,  ' ', 0, new int[] {r,g,b});
             matrix[row+1][col-1].setValues(counter, ' ', 0, new int[] {r,g,b});
             
             matrix[row][col].setCheck(false);
             matrix[row][col+1].setCheck(false);
             matrix[row+1][col].setCheck(false);
             matrix[row+1][col-1].setCheck(false); //The will have a operation asigned
             
             //Next and shapes
             matrix[row][col].setNext(matrix[row][col+1]);
             matrix[row][col+1].setNext(matrix[row+1][col]);
             matrix[row+1][col].setNext(matrix[row+1][col-1]);
             
             shapesS.add(new int[]{row,col});
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
             
             int operation = (int) (Math.random() * 3);//+-*/ 
             
             if( (matrixOfValues[row][col] == 0|| matrixOfValues[row+1][col-1] == 0|| 
                     matrixOfValues[row+1][col] == 0|| matrixOfValues[row+1][col+1]== 0  )
                     && (operation== 3 || operation== 2 )){
                 operation = 0;
             }
             if((operation== 3 )  && (matrixOfValues[row][col]/matrixOfValues[row+1][col-1] < matrixOfValues[row+1][col]) 
                     && (matrixOfValues[row][col]/matrixOfValues[row+1][col-1] / matrixOfValues[row+1][col] < matrixOfValues[row+1][col+1])){
                 operation = 0;
             }
             
             int result = determineResultForValuesSquare(counter, operation, matrixOfValues[row][col],
                    matrixOfValues[row+1][col-1],matrixOfValues[row+1][col],matrixOfValues[row+1][col+1]);
             
             int r =  (int) (Math.random() * 255) + 1;
             int g =  (int) (Math.random() * 255) + 1;
             int b =  (int) (Math.random() * 255) + 1;
 
             matrix[row][col].setValues(counter, operations[operation], result, new int[] {r,g,b});//create the four nodes
             matrix[row+1][col+1].setValues(counter, ' ', 0, new int[] {r,g,b});
             matrix[row+1][col].setValues(counter,  ' ', 0, new int[] {r,g,b});
             matrix[row+1][col-1].setValues(counter, ' ', 0, new int[] {r,g,b});
             
             matrix[row][col].setCheck(false);
             matrix[row+1][col+1].setCheck(false);
             matrix[row+1][col].setCheck(false);
             matrix[row+1][col-1].setCheck(false); //The will have a operation asigned
             
             //nex and shapes
             matrix[row][col].setNext(matrix[row+1][col+1]);
             matrix[row+1][col+1].setNext(matrix[row+1][col]);
             matrix[row+1][col].setNext(matrix[row+1][col-1]);
             
             shapesT.add(new int[]{row,col});
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
             
              int operation = (int) (Math.random() * 3);//+-*/ 
              
              if( (matrixOfValues[row][col] == 0|| matrixOfValues[row+1][col] == 0|| 
                     matrixOfValues[row+2][col] == 0|| matrixOfValues[row+3][col]== 0  )
                     && (operation== 3 || operation== 2 )){
                 operation = 0;
             }
              if( (operation== 3 )  && (matrixOfValues[row][col]/matrixOfValues[row+1][col] < matrixOfValues[row+2][col]) 
                     && (matrixOfValues[row][col]/matrixOfValues[row+1][col] / matrixOfValues[row+2][col] < matrixOfValues[row+3][col])){
                 operation = 0;
             }
              
             int result = determineResultForValuesSquare(counter,operation,matrixOfValues[row][col],
                     matrixOfValues[row+1][col],matrixOfValues[row+2][col],matrixOfValues[row+3][col]);
             
             int r =  (int) (Math.random() * 255) + 1;
             int g =  (int) (Math.random() * 255) + 1;
             int b =  (int) (Math.random() * 255) + 1;
 
             matrix[row][col].setValues(counter, operations[operation], result, new int[] {r,g,b});//create the four nodes
             matrix[row+1][col].setValues(counter, ' ', 0, new int[] {r,g,b});
             matrix[row+2][col].setValues(counter,  ' ', 0, new int[] {r,g,b});
             matrix[row+3][col].setValues(counter, ' ', 0, new int[] {r,g,b});
             
             matrix[row][col].setCheck(false);
             matrix[row+1][col].setCheck(false);
             matrix[row+2][col].setCheck(false);
             matrix[row+3][col].setCheck(false); //The will have a operation asigned
             
             //Next and shaps
             matrix[row][col].setNext(matrix[row+1][col]);
             matrix[row+1][col].setNext(matrix[row+2][col]);
             matrix[row+2][col].setNext(matrix[row+3][col]);
             
             shapesStick.add(new int[]{row,col});
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
             
             int operation = (int) (Math.random() * 3);//+-*/ 
             
             if( (matrixOfValues[row][col] == 0|| matrixOfValues[row][col+1] == 0|| 
                     matrixOfValues[row][col+2] == 0|| matrixOfValues[row][col+3]== 0  )
                     && (operation== 3 || operation== 2 )){
                 operation = 0;
             }
             
             if((operation== 3 )  && (matrixOfValues[row][col]/matrixOfValues[row][col+1] < matrixOfValues[row][col+2]) 
                     && (matrixOfValues[row][col]/matrixOfValues[row][col+1] / matrixOfValues[row][col+2] < matrixOfValues[row][col+3])){
                 operation = 0;
             }
             
             int result = determineResultForValuesSquare(counter,operation,matrixOfValues[row][col],
                     matrixOfValues[row][col+1],matrixOfValues[row][col+2],matrixOfValues[row][col+3]);
             
             int r =  (int) (Math.random() * 255) + 1;
             int g =  (int) (Math.random() * 255) + 1;
             int b =  (int) (Math.random() * 255) + 1;
 
             matrix[row][col].setValues(counter, operations[operation], result, new int[] {r,g,b});//create the four nodes
             matrix[row][col+1].setValues(counter, ' ', 0, new int[] {r,g,b});
             matrix[row][col+2].setValues(counter,  ' ', 0, new int[] {r,g,b});
             matrix[row][col+3].setValues(counter, ' ', 0, new int[] {r,g,b});
             
             matrix[row][col].setCheck(false);
             matrix[row][col+1].setCheck(false);
             matrix[row][col+2].setCheck(false);
             matrix[row][col+3].setCheck(false); //The will have a operation asigned
             
             //Next and hsapes
             matrix[row][col].setNext(matrix[row][col+1]);
             matrix[row][col+1].setNext(matrix[row][col+2]);
             matrix[row][col+2].setNext(matrix[row][col+3]);
             
             shapesStick.add(new int[]{row,col});
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
             
             int operation = (int) (Math.random() * 3);//+-*/ 
             
             if( (matrixOfValues[row][col] == 0|| matrixOfValues[row+1][col] == 0|| 
                     matrixOfValues[row+2][col] == 0|| matrixOfValues[row+2][col+1]== 0  )
                     && (operation== 3 || operation== 2 )){
                 operation = 0;
             }
             if((operation== 3 )  && (matrixOfValues[row][col]/matrixOfValues[row+1][col] < matrixOfValues[row+2][col]) &&
                     (matrixOfValues[row][col]/matrixOfValues[row+1][col] / matrixOfValues[row+2][col] < matrixOfValues[row+2][col+1] )){
                 operation = 0;
             }
             
             int result = determineResultForValuesSquare(counter,operation,matrixOfValues[row][col],
                     matrixOfValues[row+1][col],matrixOfValues[row+2][col],matrixOfValues[row+2][col+1]);
             
             int r =  (int) (Math.random() * 255) + 1;
             int g =  (int) (Math.random() * 255) + 1;
             int b =  (int) (Math.random() * 255) + 1;
 
             matrix[row][col].setValues(counter, operations[operation], result, new int[] {r,g,b});//create the four nodes
             matrix[row+1][col].setValues(counter, ' ', 0, new int[] {r,g,b});
             matrix[row+2][col].setValues(counter,  ' ', 0, new int[] {r,g,b});
             matrix[row+2][col+1].setValues(counter, ' ', 0, new int[] {r,g,b});
             
             matrix[row][col].setCheck(false);
             matrix[row+1][col].setCheck(false);
             matrix[row+2][col].setCheck(false);
             matrix[row+2][col+1].setCheck(false); //The will have a operation asigned
             
             //Next and shapes
             matrix[row][col].setNext(matrix[row+1][col]);
             matrix[row+1][col].setNext(matrix[row+2][col]);
             matrix[row+2][col].setNext(matrix[row+2][col+1]);
             
             shapesL.add(new int[]{row,col});
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
             
             int operation = (int) (Math.random() * 3);//+-*/ 
             
             if( (matrixOfValues[row][col] == 0|| matrixOfValues[row][col+1] == 0|| 
                     matrixOfValues[row][col+2] == 0|| matrixOfValues[row+1][col+2]== 0  )
                     && (operation== 3 || operation== 2 )){
                 operation = 0;
             }
             
             if((operation== 3 )  && (matrixOfValues[row][col]/matrixOfValues[row][col+1] < matrixOfValues[row][col+2]) 
                     && (matrixOfValues[row][col]/matrixOfValues[row][col+1] / matrixOfValues[row][col+2] < matrixOfValues[row+1][col+2])){
                 operation = 0;
             }
             int result = determineResultForValuesSquare(counter,operation,matrixOfValues[row][col],
                     matrixOfValues[row][col+1],matrixOfValues[row][col+2],matrixOfValues[row+1][col+2]);
             
             int r =  (int) (Math.random() * 255) + 1;
             int g =  (int) (Math.random() * 255) + 1;
             int b =  (int) (Math.random() * 255) + 1;
 
             matrix[row][col].setValues(counter, operations[operation], result, new int[] {r,g,b});//create the four nodes
             matrix[row][col+1].setValues(counter, ' ', 0, new int[] {r,g,b});
             matrix[row][col+2].setValues(counter,  ' ', 0, new int[] {r,g,b});
             matrix[row+1][col+2].setValues(counter, ' ', 0, new int[] {r,g,b});
             
             matrix[row][col].setCheck(false);
             matrix[row][col+1].setCheck(false);
             matrix[row][col+2].setCheck(false);
             matrix[row+1][col+2].setCheck(false); //The will have a operation asigned
             
             //Next and shapes
             matrix[row][col].setNext(matrix[row][col+1]);
             matrix[row][col+1].setNext(matrix[row][col+2]);
             matrix[row][col+2].setNext(matrix[row+1][col+2]);
             
             shapesL.add(new int[]{row,col});
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
                 allPermutations.put(idShape, permutationsAddSub(2,result,1));
                 break;
             case 1:
                 result =value1 - value2;
                 allPermutations.put(idShape, permutationsAddSub(2,result,2));
                 break;
             case 2:
                 result =value1 * value2;
                 allPermutations.put(idShape, multiplication2(result));
                 break;
             case 3://  divi 
                 result =value1 / value2;
                 allPermutations.put(idShape, permutationsDivision(2,result));
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
         if((value1 == 0 || value2 == 0 || value3 == 0 || value4 == 0) && (operation == 2 || operation == 3 ) ){
             operation = 0;
         }
         switch (operation) {
             case 0:
                 result = value1 + value2 + value3 + value4;
                 allPermutations.put(idShape, permutationsAddSub(4,result,1));
                 break;
             case 1:
                 result = -value1 - value2 - value3 - value4;
                 allPermutations.put(idShape, permutationsAddSub(4,result,2));
                 break;
             case 2:
                 result = value1 * value2 * value3 * value4;
                 allPermutations.put(idShape, permutationsAddSub (4,result,3));
                 break;
             case 3: 
                 result = value1 / value2 / value3 / value4;
                 allPermutations.put(idShape, permutationsDivision (4,result)); //DIVITION
                 break;
             default:
                 break;
         }
         return result;
     }
     
    private boolean elementsRepeat(int[] permutation){
        int c = 0;
        for(int x = 0; x < permutation.length; x++){
            int element = permutation[x];
            for(int i = 0; i < permutation.length; i++){
                if(element == permutation[i]){
                    c++;
                }
            }
            if(c >= 3){
                return true;
            }
            c = 0;
        }
        return false;
    }
     
      //Permutations 
      private ArrayList<int[]> module(int result){//IDK yet if it is going to be moved 
          
          ArrayList<int[]> pairs = new ArrayList<>();
          for(int i = getMinRangeValue(); i < getMaxRangeValue() + 1 ; i++){
              for(int j = getMinRangeValue() ; j < getMaxRangeValue() + 1 ; j++ ){
                  if( j == 0){
                      continue;
                  }
                  if( i%j == result){
                      if(i != j){
                          pairs.add(new int[] {i,j} ); 
                          //System.out.println(Integer.toString(i) + " " +Integer.toString(j));
                      }
                  }
              }
          }
          return pairs;
      }
      
      private ArrayList<int[]> power(int result){
          ArrayList<int[]> uniqueValue = new ArrayList<>();
          int finalValue = (int) (Math.pow(result+1, (1.0/3.0)));
          uniqueValue.add(new int[]{finalValue});
          return uniqueValue;
      }
    
    public ArrayList<int[]>  multiplication2(int result){
        ArrayList<int[]> pairs = new ArrayList<>();
        for (int i = 0; i < size; i++) {
            for (int j = 0; j < size; j++) {
                if(j == 0 || i == 0 || i == j)
                    continue;
                if( i * j == result){
                    //System.out.println(Integer.toString(i) +" " +Integer.toString(j)  );
                    pairs.add(new int[]{i,j});
                }
            }
        }
        return pairs;
    }
    
    public ArrayList<int[]>  divition2(int result){
        ArrayList<int[]> pairs = new ArrayList<>();
        for (int i = 0; i < size; i++) {
            for (int j = i; j > 0; j--) {
                if( i / j == result && i != j){
                    //System.out.println(Integer.toString(i) +" " +Integer.toString(j)  );
                    pairs.add(new int[]{i,j});
                }
            }
        }
        return pairs;
    }
      
    private int getMaxRangeValue(){
        return size-1;
    }
      
    private int getMinRangeValue(){
        return 0;
    }
      
    private void swapValues(int[] permutation){
        int temp = permutation[0];
        permutation[0] = permutation[1];
        permutation[1] = temp;
    }
    
    private ArrayList<int[]> permutationsAddSub(int cells, int value, int operation){
        ArrayList<int[]> permutations = new ArrayList<>();
        if(cells == 2){
            if(operation == 2){
                value = -value;
            }
            addittionSubtracttion2Cells(permutations, value);
        }
        if(cells == 4){
            addSubProd4Cells(permutations, value, operation);
        }
        return permutations;
    }
     
    private ArrayList<int[]> addittionSubtracttion2Cells(ArrayList<int[]> permutations, int value){
        int maxValue = getMaxRangeValue();
        int minValue = getMinRangeValue();
        int[] newPermutation;
        while((maxValue > value) && (maxValue > minValue)){
            maxValue--;
        }
        minValue = value - maxValue;
        int[] permutation = new int[] {minValue, maxValue};
        if(maxValue > 0){
            while(permutation[0] <= maxValue){
                if(permutation[0] != permutation[1]){
                    newPermutation = new int[] {permutation[0], permutation[1]};
                    permutations.add(newPermutation);
                }
                permutation[0]++;
                permutation[1]--;
            }
            return permutations;
        }
        if(maxValue < 0){
            while(permutation[1] <= minValue){
                if(permutation[0] != permutation[1]){
                    newPermutation = new int[] {permutation[0], permutation[1]};
                    permutations.add(newPermutation);
                }
                permutation[0]++;
                permutation[1]--;
            }
            return permutations;
        }
        if(maxValue == 0){
            int maxRangeValue = getMaxRangeValue();
            if(permutation[0] != permutation[1]){
                newPermutation = new int[] {permutation[0], permutation[1]};
                permutations.add(newPermutation);
            }
            permutation[0]++;
            permutation[1]--;
            while(permutation[0] <= maxRangeValue){
                if(permutation[0] != permutation[1]){
                    newPermutation = new int[] {permutation[0], permutation[1]};
                    permutations.add(newPermutation);
                    swapValues(newPermutation);
                    newPermutation = new int[] {permutation[0], permutation[1]};
                    permutations.add(newPermutation);
                }
                permutation[0]++;
                permutation[1]--;
            }
            return permutations;
        }
        return permutations;
    }
    
    private void addSubProd4Cells(ArrayList<int[]> permutations, int value, int operation){
        int minValue = getMinRangeValue();
        int maxValue = getMaxRangeValue();
        int[] permutation = new int[] {maxValue, maxValue, maxValue, maxValue};
        while(permutation[3] >= minValue){
            while(permutation[2] >= minValue){
                while(permutation[1] >= minValue){
                    while(permutation[0] >= minValue){
                        int[] newPermutation = new int[] {permutation[0], permutation[1], permutation[2], permutation[3]};
                        if(elementsRepeat(newPermutation) == false){
                            switch (operation) {
                                case 1:
                                    if((newPermutation[0] + newPermutation[1] + newPermutation[2] + newPermutation[3]) == value){
                                        permutations.add(newPermutation);
                                    }   break;
                                case 2:
                                    if((-newPermutation[0] - newPermutation[1] - newPermutation[2] - newPermutation[3]) == value){
                                        permutations.add(newPermutation);
                                    }   break;
                                case 3:
                                    if((newPermutation[0] * newPermutation[1] * newPermutation[2] * newPermutation[3]) == value){
                                        permutations.add(newPermutation);
                                    }   break;
                                default:
                                    break;
                            }
                        }
                        permutation[0]--;
                    }
                    permutation[0] = maxValue;
                    permutation[1]--;
                }
                permutation[0] = maxValue;
                permutation[1] = maxValue;
                permutation[2]--;
            }
            permutation[0] = maxValue;
            permutation[1] = maxValue;
            permutation[2] = maxValue;
            permutation[3]--;
        }
    }
    
    private ArrayList<int[]> permutationsDivision(int cells, int value){
        ArrayList<int[]> permutations = new ArrayList<>();
        if(cells == 2){
            division2Cells(permutations, value);
        }
        if(cells == 4){
            division4Cells(permutations, value);
        }
        return permutations;
    }
    
    private void division2Cells(ArrayList<int[]> permutations, int value){
        int maxValue = getMaxRangeValue();
        int[] permutation = new int[]{maxValue, maxValue, maxValue, maxValue};
        while(permutation[0] >= 1){
            while(permutation[1] >= 1){
                if(permutation[0] != permutation[1]){
                    if((permutation[0]/permutation[1]) == value){
                        int[] newPermutation = new int[] {permutation[0], permutation[1]};
                        permutations.add(newPermutation);
                    }
                }
                permutation[1]--;
            }
            permutation[0]--;
            permutation[1] = permutation[0];
        }
    }
    
    private void division4Cells(ArrayList<int[]> permutations, int value){
        int maxValue = getMaxRangeValue();
        int[] permutation = new int[]{maxValue, maxValue, maxValue, maxValue};
        while(permutation[0] >= 1){
            while(permutation[1] >= 1){
                permutation[2] = permutation[0] / permutation[1];
                while(permutation[2] >= 1){
                    permutation[3] = permutation[0] / permutation[1] / permutation[2];
                    while(permutation[3] >= 1){
                        if(elementsRepeat(permutation) == false){
                            if((((permutation[0]/permutation[1])/permutation[2])/permutation[3]) == value){
                                int[] newPermutation = new int[]{permutation[0], permutation[1], permutation[2], permutation[3]};
                                permutations.add(newPermutation);
                            }
                        }
                        permutation[3]--;
                    }
                    permutation[2]--;
                }
                permutation[1]--;
            }
            permutation[0]--;
            permutation[1] = permutation[0];
        }
    }
        //Information
        public void printShape(){  
              for (int i = 0; i < shapes.size(); i++) {
                  System.out.println("Shape: " + Integer.toString(i));
                  for (int j = 0; j < shapes.get(i).size(); j++) {
                      System.out.println( Integer.toString( shapes.get(i).get(j)[0]) + " " + Integer.toString( shapes.get(i).get(j)[1]) +" " +  Integer.toString( matrix[shapes.get(i).get(j)[0]][shapes.get(i).get(j)[1]].getCounter() )) ;
                  }
              }
          } 
        
        public void iterarPermutaciones(){  
             Iterator iterator = allPermutations.entrySet().iterator();
             while (iterator.hasNext()) {
                 Map.Entry me2 = (Map.Entry) iterator.next();
                  ArrayList<int[]> element = (ArrayList<int[]>) me2.getValue();
                  System.out.println("Key: "+me2.getKey());
                 for (int i = 0; i < element.size(); i++) {
                     System.out.print("Elementos permutacion: ");
                     for (int j = 0; j < element.get(i).length; j++) {
                         System.out.print(Integer.toString(  element.get(i)[j]  )+ "\t");
                     }
                     System.out.println("");
                 }
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
