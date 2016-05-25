package task.Exception;

/**
 * Created by Артем on 16.05.2016.
 */
public class NegativePriceException extends Exception {
    public NegativePriceException(){}
    public NegativePriceException(String message){
        super(message);
    }
}