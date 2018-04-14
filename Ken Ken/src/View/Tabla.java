package View;


import java.awt.Color;
import javax.swing.JButton;
import javax.swing.JTable;
import javax.swing.table.DefaultTableModel;
import Model.*;

public class Tabla {
    
    public void ver_tabla(JTable pTabla,int cantidadVertices, NodekenKen matriz[][]){
        
        pTabla.setDefaultRenderer(Object.class, new Render());
        DefaultTableModel tablaPredeterminada = new DefaultTableModel(){
            public boolean isCellEditable(int row,int column){
                return false;
            }
        };
        tablaPredeterminada.addColumn("   ");
        for(int i = 0; i<cantidadVertices-1; i++){
            tablaPredeterminada.addColumn("");
        }
        
        Object fila[] = new Object[cantidadVertices+1];
        if(cantidadVertices > 0){
            for(int i=0; i<cantidadVertices; i++){
                fila[0] ="";
                for(int j = 0 ; j<cantidadVertices; j++){
                    JButton botonPeso;
                    if(matriz[i][j].getOperator() == ' '){
                        botonPeso = new JButton(Integer.toString(matriz[i][j].getValue()));
                    }
                    else{
                        botonPeso = new JButton(Integer.toString(matriz[i][j].getResult()) + " " +matriz[i][j].getOperator() + 
                                " " +Integer.toString(matriz[i][j].getValue()));
                    }
                    Color c = new Color(matriz[i][j].getRGB()[0],matriz[i][j].getRGB()[1],matriz[i][j].getRGB()[2]);
                    botonPeso.setBackground(c);
                    fila[j] =botonPeso;
                }
                tablaPredeterminada.addRow(fila);
            }
        }
        pTabla.setModel(tablaPredeterminada);
        pTabla.setRowHeight(20);
    }
}
