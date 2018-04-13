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
public class KenKen {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        matrix matrix = new matrix(5);
        proto view = new proto(matrix.matrix,5);
        view.setVisible(true);
        
    }
}
