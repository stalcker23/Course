package task.Exception;

/**
 * Created by Артем on 17.05.2016.
 */
public class NegativeWeightException extends Exception {
    public NegativeWeightException(){}
    public NegativeWeightException(String message){
        super(message);
    }
}