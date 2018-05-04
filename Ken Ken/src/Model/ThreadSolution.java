/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Model;

import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author jose pablo
 */
public class ThreadSolution extends Thread{

    private KenKen kenken;
    private Solution child;
    private int sectionId;
    
    
    public ThreadSolution(String msg,KenKen pKenKen,Solution pChild, int pSectionId){
        super(msg);
        kenken = pKenKen; 
        child = pChild;
        sectionId = pSectionId;
    }
    
    public void run(){
        kenken.backTrackingThreads(child, sectionId);
        kenken.setCurrentThreads( kenken.getCurrentThreads() - 1);
        try {
            this.finalize();
        } catch (Throwable ex) {
            Logger.getLogger(ThreadSolution.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
}
