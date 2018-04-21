/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package View;

import Model.KenKen;
import Model.Solution;
import Model.TableUpdater;
import com.thoughtworks.xstream.XStream;
import com.thoughtworks.xstream.io.xml.DomDriver;
import java.awt.Font;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.PrintWriter;
import java.util.ArrayList;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.JScrollPane;
import javax.swing.JTable;


/**
 *
 * @author jose pablo
 */
public class proto extends javax.swing.JFrame {

    public Tabla tablaBase = new Tabla();
    int size;
    private FileReader readerKenKen = null;
    private final XStream xstream;
    private PrintWriter out = null;
    private String xml;
    private KenKen kenkenMatrix;
    
    public proto() {
        initComponents();
        kenkenMatrix = new KenKen(5);
        xstream = new XStream(new DomDriver());
        kenkentable.setAutoResizeMode(JTable.AUTO_RESIZE_OFF);
        
    }
    
    
    public void loadXML(){//Move to controller??
        try {
            readerKenKen = new FileReader("kenkenTemplate.xml");
        }
        catch (FileNotFoundException ex) {
            Logger.getLogger(proto.class.getName()).log(Level.SEVERE, null, ex);
        }
        ArrayList<String> data = (ArrayList<String>) (xstream.fromXML(readerKenKen));
        kenkenMatrix = (KenKen) (xstream.fromXML(data.get(0)));
        size =  (Integer) (xstream.fromXML(data.get(1)));
        tablaBase.ver_tabla( kenkentable, size,  kenkenMatrix.getMatrix() );
    }
    
        public  void saveXML(){//Move to controller??
        try {
            out = new PrintWriter("kenkenTemplate.xml");
        }
        catch (FileNotFoundException ex){
            Logger.getLogger(proto.class.getName()).log(Level.SEVERE, null, ex);
        }
        ArrayList<String> data = new ArrayList<>();
        xml = xstream.toXML(kenkenMatrix);
        data.add(xml);
        xml = xstream.toXML(size);
        data.add(xml);
        xml = xstream.toXML(data);
        out.println(xml);
        out.close();
    }
    
    /**
     * This method is called from within the constructor to initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is always
     * regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        saveBT = new javax.swing.JButton();
        loadBT = new javax.swing.JButton();
        generateBT = new javax.swing.JButton();
        sizeOfKenKen = new javax.swing.JSpinner();
        jLabel1 = new javax.swing.JLabel();
        sizeLB = new javax.swing.JLabel();
        threadsLB = new javax.swing.JLabel();
        threadsSP = new javax.swing.JSpinner();
        solveBT = new javax.swing.JButton();
        jScrollPane1 = new javax.swing.JScrollPane();
        kenkentable = new javax.swing.JTable();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);
        setBackground(new java.awt.Color(0, 0, 0));

        saveBT.setText("Save");
        saveBT.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                saveBTActionPerformed(evt);
            }
        });

        loadBT.setText("Load");
        loadBT.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                loadBTActionPerformed(evt);
            }
        });

        generateBT.setText("Generate");
        generateBT.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                generateBTActionPerformed(evt);
            }
        });

        jLabel1.setFont(new java.awt.Font("Dialog", 1, 24)); // NOI18N
        jLabel1.setForeground(new java.awt.Color(0, 0, 204));
        jLabel1.setText("KenKen (ケンケン)");

        sizeLB.setText("Size");

        threadsLB.setText("Threads");

        solveBT.setText("Solve");
        solveBT.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                solveBTActionPerformed(evt);
            }
        });

        kenkentable.setModel(new javax.swing.table.DefaultTableModel(
            new Object [][] {
                {null, null, null, null},
                {null, null, null, null},
                {null, null, null, null},
                {null, null, null, null}
            },
            new String [] {
                "Title 1", "Title 2", "Title 3", "Title 4"
            }
        ));
        jScrollPane1.setViewportView(kenkentable);

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(jScrollPane1)
                    .addGroup(layout.createSequentialGroup()
                        .addComponent(loadBT)
                        .addGap(18, 18, 18)
                        .addComponent(saveBT)
                        .addGap(18, 18, 18)
                        .addComponent(generateBT)
                        .addGap(18, 18, 18)
                        .addComponent(sizeLB)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                        .addComponent(sizeOfKenKen, javax.swing.GroupLayout.PREFERRED_SIZE, 64, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                        .addComponent(threadsLB)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                        .addComponent(threadsSP, javax.swing.GroupLayout.PREFERRED_SIZE, 68, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, 691, Short.MAX_VALUE)
                        .addComponent(solveBT, javax.swing.GroupLayout.PREFERRED_SIZE, 75, javax.swing.GroupLayout.PREFERRED_SIZE))
                    .addGroup(layout.createSequentialGroup()
                        .addComponent(jLabel1, javax.swing.GroupLayout.PREFERRED_SIZE, 371, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addGap(0, 0, Short.MAX_VALUE)))
                .addContainerGap())
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addComponent(jLabel1, javax.swing.GroupLayout.PREFERRED_SIZE, 33, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addGap(18, 18, 18)
                .addComponent(jScrollPane1, javax.swing.GroupLayout.DEFAULT_SIZE, 510, Short.MAX_VALUE)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(saveBT)
                    .addComponent(generateBT)
                    .addComponent(sizeOfKenKen, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(sizeLB)
                    .addComponent(threadsLB)
                    .addComponent(threadsSP, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(solveBT)
                    .addComponent(loadBT))
                .addContainerGap())
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void saveBTActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_saveBTActionPerformed
        saveXML();
    }//GEN-LAST:event_saveBTActionPerformed

    private void loadBTActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_loadBTActionPerformed
        loadXML();
    }//GEN-LAST:event_loadBTActionPerformed

    private void generateBTActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_generateBTActionPerformed
        size = (int) this.sizeOfKenKen.getValue();
        kenkenMatrix = new KenKen( size );
        kenkenMatrix.changeMatrix( size );
        tablaBase.ver_tabla( kenkentable, size,  kenkenMatrix.getMatrix());
    }//GEN-LAST:event_generateBTActionPerformed

    private void solveBTActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_solveBTActionPerformed
        Solution solved = kenkenMatrix.solveKenKen();
        if(solved.isFailure() == false){
            kenkenMatrix.setMatrix(solved.getMatrix()); 
            tablaBase.ver_tabla( kenkentable, size,  kenkenMatrix.getMatrix());
        }
        else{
            System.out.println("no hay");
        }
        //kenkenMatrix.iterarPermutaciones();
       
        //Thread thread = new TableUpdater("Proccess1",tablaBase,kenkentable, size,  kenkenMatrix.getMatrix());
        //thread.start();
    }//GEN-LAST:event_solveBTActionPerformed

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton generateBT;
    private javax.swing.JLabel jLabel1;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JTable kenkentable;
    private javax.swing.JButton loadBT;
    private javax.swing.JButton saveBT;
    private javax.swing.JLabel sizeLB;
    private javax.swing.JSpinner sizeOfKenKen;
    private javax.swing.JButton solveBT;
    private javax.swing.JLabel threadsLB;
    private javax.swing.JSpinner threadsSP;
    // End of variables declaration//GEN-END:variables
}
