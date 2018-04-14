/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package View;

import Model.NodekenKen;
import com.thoughtworks.xstream.XStream;
import com.thoughtworks.xstream.io.xml.DomDriver;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.PrintWriter;
import java.util.ArrayList;
import java.util.logging.Level;
import java.util.logging.Logger;


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
    private NodekenKen kenkenMatrix[][];
    
    public proto(NodekenKen matrix[][] ,int pSize) {
        initComponents();
        size = pSize;
        kenkenMatrix = matrix;
        tablaBase.ver_tabla( kenkentable, size,  kenkenMatrix);
        xstream = new XStream(new DomDriver());
    }
    
    
    public void loadXML(){//Move to controller??
        try {
            readerKenKen = new FileReader("kenkenTemplate.xml");
        }
        catch (FileNotFoundException ex) {
            Logger.getLogger(proto.class.getName()).log(Level.SEVERE, null, ex);
        }
        ArrayList<String> data = (ArrayList<String>) (xstream.fromXML(readerKenKen));
        kenkenMatrix = (NodekenKen[][]) (xstream.fromXML(data.get(0)));
        size =  (Integer) (xstream.fromXML(data.get(1)));
        tablaBase.ver_tabla( kenkentable, size,  kenkenMatrix);
        
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

        jScrollPane1 = new javax.swing.JScrollPane();
        kenkentable = new javax.swing.JTable();
        saveBT = new javax.swing.JButton();
        loadBT = new javax.swing.JButton();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);

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

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(jScrollPane1, javax.swing.GroupLayout.DEFAULT_SIZE, 713, Short.MAX_VALUE)
                    .addGroup(layout.createSequentialGroup()
                        .addComponent(saveBT)
                        .addGap(38, 38, 38)
                        .addComponent(loadBT)
                        .addGap(0, 0, Short.MAX_VALUE)))
                .addContainerGap())
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addComponent(jScrollPane1, javax.swing.GroupLayout.PREFERRED_SIZE, 202, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addGap(100, 100, 100)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(saveBT)
                    .addComponent(loadBT))
                .addContainerGap(108, Short.MAX_VALUE))
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void saveBTActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_saveBTActionPerformed
        saveXML();
    }//GEN-LAST:event_saveBTActionPerformed

    private void loadBTActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_loadBTActionPerformed
        loadXML();
    }//GEN-LAST:event_loadBTActionPerformed

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JTable kenkentable;
    private javax.swing.JButton loadBT;
    private javax.swing.JButton saveBT;
    // End of variables declaration//GEN-END:variables
}