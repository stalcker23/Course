package task;

import java.io.Serializable;
import java.util.List;

/**
 * Created by Артем on 15.05.2016.
 */
public class Order implements Serializable {
    private List<Meal> products;
    private Person person;
    private int costOrder;

    public Order(List<Meal> products, Person person) {
        this.products = products;
        this.person = person;
        costOrder = 0;
    }

    public Person getPerson() {
        return person;
    }

    public List<Meal> getProducts() {
        return products;
    }

    public int getCostOrder() {
        return costOrder;
    }

    public void setCostOrder(int cost) {
        costOrder = cost;
    }

    @Override
    public String toString() {
        return String.format("\n"+person + stringOfProducts());
    }

    public String toStringForPerson() {
        return String.format(stringOfProducts());
    }

    private String stringOfProducts() {
        StringBuilder result = new StringBuilder();
        for (Meal meal: products) {
            result.append("\n"+meal );
        }

        return result.toString();
    }






}
