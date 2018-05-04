/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Model;
import View.Tabla;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.JTable;
/**
 *
 * @author jose pablo
 */
public class TableUpdater extends Thread{
    private Tabla baseTable;
    private JTable table;
    private KenKen kenken;
    
    public TableUpdater(String msg,Tabla pBaseTable,JTable pTable,KenKen pKenKen){
        super(msg);
        baseTable = pBaseTable;
        table = pTable;
        kenken = pKenKen; 
    }
    
    public void run(){
        
        try {
            while(kenken.isFinished() == false){
                Thread.sleep(500);
                kenken.setDesing();
                baseTable.ver_tabla(table, kenken.getSize(), kenken.getIlustrator());
            }
        }
        catch (InterruptedException ex) {
           Logger.getLogger(TableUpdater.class.getName()).log(Level.SEVERE, null, ex);
       }
        catch (Exception ex) {
            Logger.getLogger(TableUpdater.class.getName()).log(Level.SEVERE, null, ex);
            System.out.println("Catch");
        }
    }
}
