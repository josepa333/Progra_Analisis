/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Application;

import Model.KenKen;
import View.proto;

/**
 *
 * @author jose pablo
 */
public class App {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        KenKen matrix = new KenKen(10);
        proto view = new proto(matrix.getMatrix(),10);
        view.setVisible(true);
    }
}
