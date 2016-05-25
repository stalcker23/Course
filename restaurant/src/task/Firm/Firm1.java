package task.Firm;

import java.io.FileOutputStream;
import java.io.IOException;
import java.io.Serializable;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.io.ObjectOutputStream;
import task.Meal;
import task.Order;
import task.Person;
import task.Restaurant.AbstractRestaurant;
import task.Restaurant.ConcreteRestaurant;

/**
 * Created by Артем on 15.05.2016.
 */
public class Firm1 extends AbstractFirm implements  Serializable {
    private AbstractRestaurant restaurant;
    private List<Person> peoples = new ArrayList<>();
    private List<Order> orders = new ArrayList<>();

    public Firm1(AbstractRestaurant restaurant) {
        this.restaurant = restaurant;
        this.AddedPerson();
    }

    private void AddedPerson() {
        peoples.add(new Person("А.", "Пупкин"));
        peoples.add(new Person("С.", "Кривенко"));
        peoples.add(new Person("П.", "Гайченков"));
    }
    @Override
    public void sendOrder() {
        ConcreteRestaurant rest = (ConcreteRestaurant)restaurant;
        try {
            List<Meal> order_1 = new ArrayList<>();
            order_1.add(rest.getMenu().get(3));
            order_1.add(rest.getMenu().get(11));
            order_1.add(rest.getMenu().get(15));
            order_1.add(rest.getMenu().get(0));
            Order order1 = new Order(order_1, peoples.get(0));
            orders.add(order1);

            List<Meal> order_2 = new ArrayList<>();
            order_2.add(rest.getMenu().get(4));
            order_2.add(rest.getMenu().get(7));
            order_2.add(rest.getMenu().get(11));
            order_2.add(rest.getMenu().get(13));
            order_2.add(rest.getMenu().get(2));
            Order order2 = new Order(order_2, peoples.get(1));
            orders.add(order2);



            List<Meal> order_3 = new ArrayList<>();
            order_3.add(rest.getMenu().get(8));
            order_3.add(rest.getMenu().get(11));
            order_3.add(rest.getMenu().get(0));
            order_3.add(rest.getMenu().get(1));
            Order order3 = new Order(order_3, peoples.get(2));
            orders.add(order3);
        }

        catch (ArrayIndexOutOfBoundsException e)
        {
            System.out.println("Ошибка с добавлением блюда к клиенту");
            System.exit(0);
        }
        rest.getOrder(orders);
        this.writeReport();

        orders.clear();
    }

    public void writeReport() {
        System.out.println("\nОтчет клиентам");
        for(Order order: orders) {
            System.out.println(order.toString());
            System.out.println(order.getCostOrder() + "руб.");
        }
    }
}