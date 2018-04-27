/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Model;



/**
 *
 *  @author Jose Pablo
 */


public class Stopwatch { 

    private final long start;
    
    public Stopwatch() {
        start = System.currentTimeMillis();
    } 

    public double elapsedTime() {
        long now = System.currentTimeMillis();
        return (now - start) / 1000.0;
    }
} 