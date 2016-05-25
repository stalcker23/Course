package task;

import java.io.Serializable;

/**
 * Created by Артем on 15.05.2016.
 */
public class Person implements Serializable {
    private String firstName;
    private String secondName;
//    private List<Meal> order = new ArrayList<Meal>();

    public Person(String firstName, String secondName) {
        this.setFirstName(firstName);
        this.setSecondName(secondName);
    }

    public String getFirstName() {
        return firstName;
    }

    public void setFirstName(String value) {


        firstName = value;
    }

    public String getSecondName() {
        return secondName;
    }

    public void setSecondName(String value) {

        secondName = value;
    }

//    public List<Meal> getOrder()
//    {
//        return order;
//    }
//
//    public void setOrder(List<Meal> newOrder) {
//        order = newOrder;
//    }

    @Override
    public String toString() {
        return String.format(firstName+" " + secondName+"\n");
    }
}

