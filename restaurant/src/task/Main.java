package task;

import task.Firm.AbstractFirm;
import task.Firm.Firm1;
import task.Restaurant.ConcreteRestaurant;
import task.Restaurant.MyRest;

import java.io.*;
import java.lang.reflect.Array;
import java.util.ArrayList;
import java.util.List;

/**
 * Created by Артем on 15.05.2016.
 */
public class Main implements  Serializable {

    public static void main(String[] args) throws Exception {

        AbstractFirm firm = new Firm1(new ConcreteRestaurant());
        AbstractFirm firm2;
        String filename = "D:\\time.ser";
        FileOutputStream fos = null;
        ObjectOutputStream out = null;
        try {
            fos = new FileOutputStream(filename);
            out = new ObjectOutputStream(fos);
            out.writeObject(firm);
            out.close();
        } catch (IOException ex) {
            ex.printStackTrace();
        }
        firm.sendOrder();

        try {
            FileInputStream fis = new FileInputStream("time.ser");
            BufferedInputStream bis = new BufferedInputStream(fis);
            ObjectInputStream ois = new ObjectInputStream(bis);
            firm2 = (Firm1) ois.readObject();
            ois.close();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}

