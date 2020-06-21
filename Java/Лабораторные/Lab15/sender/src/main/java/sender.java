import com.sun.messaging.ConnectionConfiguration;
import com.sun.messaging.ConnectionFactory;
import com.sun.messaging.Destination;
import com.sun.messaging.jms.JMSException;

import javax.jms.JMSContext;
import javax.jms.JMSProducer;

public class sender {
    public static void main(String[] args) throws javax.jms.JMSException {
        ConnectionFactory factory;
        factory = new ConnectionFactory();
        try(JMSContext context = factory.createContext("admin","admin")) {
            factory.setProperty(ConnectionConfiguration.imqAddressList, "mq://127.0.0.1:7676,mq://127.0.0.1:7676");
            Destination cardsQueue = (Destination) context.createQueue("BankCardQueue");
            JMSProducer producer = context.createProducer();
            // Send msg about card
            producer.send(cardsQueue,"MY FIRST MESSAGE IN JMS");
            System.out.println("send");
        } catch (JMSException e){
            System.out.println("Error: " + e.getMessage());
        }
    }
}
