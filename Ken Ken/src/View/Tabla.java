package View;


import java.awt.Color;
import javax.swing.JButton;
import javax.swing.JTable;
import javax.swing.table.DefaultTableModel;
import Model.*;
import java.awt.Font;

public class Tabla {
    
    public void ver_tabla(JTable pTabla,int size, NodekenKen matriz[][]){
        
        pTabla.setDefaultRenderer(Object.class, new Render());
        DefaultTableModel tablaPredeterminada = new DefaultTableModel(){
            public boolean isCellEditable(int row,int column){
                return false;
            }
        };
        tablaPredeterminada.addColumn("   ");
        for(int i = 0; i<size-1; i++){
            tablaPredeterminada.addColumn(Integer.toString(i+1));
        }
        
        Object fila[] = new Object[size+1];
        if(size > 0){
            for(int i=0; i<size; i++){
                fila[0] ="";
                for(int j = 0 ; j<size; j++){
                    JButton botonPeso;
                    NodekenKen x = matriz[i][j];
                    if(x.getOperator() == ' '){
                        botonPeso = new JButton(Integer.toString(matriz[i][j].getValue()));
                    }
                    else{
                        botonPeso = new JButton( matriz[i][j].getOperator() +Integer.toString(matriz[i][j].getResult())+ 
                                " " +Integer.toString(matriz[i][j].getValue()));
                    }
                    Color c = new Color(matriz[i][j].getRGB()[0],matriz[i][j].getRGB()[1],matriz[i][j].getRGB()[2]);
                    botonPeso.setBackground(c);
                    botonPeso.setFont(new Font("Serif",Font.BOLD,12));//12 para  5 esta bien 
                    if(size > 10){
                        botonPeso.setFont(new Font("Serif",Font.BOLD,8));//12 para  5 esta bien 
                    }
                    fila[j] =botonPeso;
                    
                }
                tablaPredeterminada.addRow(fila);
            }
        }
        pTabla.setModel(tablaPredeterminada);
        pTabla.setRowHeight(50);
        for (int i = 0; i < size; i++) {
            pTabla.getColumnModel().getColumn(i).setPreferredWidth(100);
        }
    }
}
