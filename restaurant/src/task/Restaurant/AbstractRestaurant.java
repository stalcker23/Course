package task.Restaurant;
import task.Order;

import java.io.Serializable;

/**
 * Created by Артем on 15.05.2016.
 */
public abstract class AbstractRestaurant implements  Serializable {
    public abstract int getOrder(Order order);
}
