/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Model;
import View.Tabla;
import javax.swing.JTable;
/**
 *
 * @author jose pablo
 */
public class TableUpdater extends Thread{
   private Tabla baseTable;
   private JTable table;
   private int size;
   private NodekenKen matrix[][];
    
    
    
    public TableUpdater(String msg,Tabla pBaseTable,JTable pTable,int pSize, NodekenKen pMatrix[][]){
        super(msg);
        baseTable = pBaseTable;
        table = pTable;
        size = pSize;
        matrix= pMatrix;
    }
    
    public void run(){
        try{
            while(true){
                System.out.println("Update");
                baseTable.ver_tabla(table, size, matrix);
                Thread.sleep(1000);
                
            }
        }
        catch(InterruptedException e){
            System.out.println("Drop table updater");
        }
    }
}
