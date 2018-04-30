/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Model;

import View.Tabla;
import javax.swing.JOptionPane;
import javax.swing.JTable;

/**
 *
 * @author jose pablo
 */
public class SolveKenKen  extends Thread{
    private Tabla baseTable;
    private JTable table;
    private KenKen kenken;
    
    public SolveKenKen(String msg,Tabla pBaseTable,JTable pTable,KenKen pKenKen){
        super(msg);
        baseTable = pBaseTable;
        table = pTable;
        kenken = pKenKen; 
    }
    
    public void run(){
        
        Thread ilustrator = new TableUpdater("Proccess1",baseTable,table, kenken);
         ilustrator.start();
        
        Stopwatch stp = new Stopwatch();
        Solution solved = kenken.solveKenKen();
        double time = stp.elapsedTime();
        System.out.printf("Solving the kenken:  %e\n", time);
        if(solved.isFailure() == false){
            kenken.setMatrix(solved.getMatrix());
            kenken.setDesing();
            baseTable.ver_tabla(table, kenken.getSize(), kenken.getIlustrator());
            JOptionPane.showMessageDialog(null, "Done");
        }
        else{
            kenken.setFinished(true);
            JOptionPane.showMessageDialog(null, "Not solved.");
        } 
    }
}
