package task;

import java.io.Serializable;

/**
 * Created by Артем on 15.05.2016.
 */
public class Meal implements Serializable {
    private String name;
    private Double price;
    private int weightOfPortions;

    public Meal(String name, Double price, int weightOfPortions) {
        this.setName(name);
        this.setPrice(price);
        this.setWeightOfPortions(weightOfPortions);
    }

    public String getName() {
        return name;
    }

    public void setName(String value){

        name = value;
    }

    public Double getPrice() {
        return price;
    }

    public void setPrice(Double value)  {
                price = value;
    }

    public int getWeightOfPortions() {
        return weightOfPortions;
    }

    public void setWeightOfPortions(int value)  {

        weightOfPortions = value;
    }

    @Override
    public String toString() {
        return String.format(name + " " + price +  " " + "руб." + " " + weightOfPortions + "гр.");
    }
}
