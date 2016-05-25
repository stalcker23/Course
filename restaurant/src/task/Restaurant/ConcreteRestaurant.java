package task.Restaurant;
import task.Exception.NegativePriceException;
import task.Exception.NegativeWeightException;
import task.Exception.EmptyNameOfProductException;
import task.Meal;
import task.Order;

import java.io.Serializable;
import java.io.*;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

/**
 * Created by Артем on 15.05.2016.
 */
public class ConcreteRestaurant extends AbstractRestaurant implements  Serializable{
    private List<Meal> menu = new ArrayList<Meal>();
    private  Map<String,Integer> itemsForRestaurant = new HashMap<String,Integer>();
    public ConcreteRestaurant() throws IOException, NegativePriceException, EmptyNameOfProductException, NegativeWeightException {
        try {
            this.InizializeMenu();
        }
            catch(IOException ex){
                System.out.println(ex.getMessage());
            }
            catch (NegativePriceException | NegativeWeightException |EmptyNameOfProductException e) {
                System.err.println(e.getMessage());
                System.exit(0);
            }

    }

    public void InizializeMenu() throws NegativePriceException,NegativeWeightException,NumberFormatException,IOException,EmptyNameOfProductException {
            File f = new File("D:\\contract.txt");
            try (Reader reader = new InputStreamReader(new FileInputStream(f), "CP1251")) {
                char[] bufferForMenu = new char[(int) f.length()];
                reader.read(bufferForMenu);
                String fullMenu = new String(bufferForMenu);
                String[] massiveOfProducts = fullMenu.split("\n");
                try {
                    for (String eachProduct : massiveOfProducts) {
                        String[] parseEachProduct = eachProduct.split(",");
                        String[] mas = parseEachProduct[2].split("\r");
                        if (Double.parseDouble(parseEachProduct[1]) < 0)
                            throw new NegativePriceException("Incorrect price");
                        else if (parseEachProduct[0].isEmpty())
                            throw new EmptyNameOfProductException("Empthy name");
                        else if (Integer.parseInt(mas[0])<0)
                            throw new NegativeWeightException("Incorrect weight of potions");
                        else
                        menu.add(new Meal(parseEachProduct[0], Double.parseDouble(parseEachProduct[1]), Integer.parseInt(mas[0])));
                    }
                }
                finally {
                    System.out.println("Файл меню обработан");
                }
            }

    }


    @Override
    public int getOrder(Order order) {
        int cost = this.costOrder(order);
        order.setCostOrder(cost);
        return cost;
    }

    public int getOrder(List<Order> orders) {
        int sum = 0;
        for (Order ord: orders) {
            sum += this.getOrder(ord);
        }

        this.WriteOrder(orders, sum);
        return sum;
    }

    private int costOrder(Order order) {
        int sum = 0;
        for(Meal meal: order.getProducts()) {
            sum += meal.getPrice();
        }

        return sum;
    }

    private void WriteOrder(List<Order> orders,int sum) {
        for (Order ord: orders) {
            {
                for(Meal item:ord.getProducts())
                    if (!itemsForRestaurant.containsKey(item.getName()))
                        itemsForRestaurant.put(item.getName(),1);
                    else itemsForRestaurant.put(item.getName(),itemsForRestaurant.get(item.getName()).intValue()+1);
            }
        }
        System.out.println("Отчет на кухню: \n");
        for(Map.Entry<String,Integer> item:itemsForRestaurant.entrySet()) {
            System.out.println(item.getKey()+" "+item.getValue() );
        }

    }



    public List<Meal> getMenu() {
        return menu;
    }}