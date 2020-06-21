package topic;

import com.sun.messaging.ConnectionConfiguration;
import com.sun.messaging.ConnectionFactory;
import com.sun.messaging.jms.JMSException;

import javax.jms.Destination;
import javax.jms.JMSContext;
import javax.jms.JMSProducer;
import javax.jms.ObjectMessage;

public class sender {
    public static void main(String[] args) throws javax.jms.JMSException {
        ConnectionFactory factory;
        factory = new ConnectionFactory();
        try (JMSContext context = factory.createContext("admin", "admin", JMSContext.CLIENT_ACKNOWLEDGE)) {
            factory.setProperty(ConnectionConfiguration.imqAddressList,
                    "mq://127.0.0.1:7676,mq://127.0.0.1:7676");
            Destination Topic = context.createTopic("Topic");
            JMSProducer producer = context.createProducer();
            producer.send(Topic, "Topic Message !!!");
            System.out.println("Send Topic Message");
        } catch (JMSException e) {
            System.out.println("Error: " + e.getMessage());
        }
    }
}
