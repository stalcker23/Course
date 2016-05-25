package task.Exception;

/**
 * Created by Артем on 17.05.2016.
 */
public class EmptyNameOfProductException extends Exception {
    public EmptyNameOfProductException(){}
    public EmptyNameOfProductException(String message){
        super(message);
    }
}