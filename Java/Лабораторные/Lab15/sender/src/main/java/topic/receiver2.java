package topic;

import com.sun.messaging.ConnectionConfiguration;
import com.sun.messaging.ConnectionFactory;

import javax.jms.Destination;
import javax.jms.JMSConsumer;
import javax.jms.JMSContext;
import javax.jms.MessageListener;

public class receiver2 implements MessageListener {
    ConnectionFactory factory = new com.sun.messaging.ConnectionFactory();
    JMSConsumer consumer;
    receiver2() throws javax.jms.JMSException {
        try( JMSContext context = factory.createContext("admin","admin")){
            factory.setProperty(ConnectionConfiguration.imqAddressList,
                    "mq://127.0.0.1:7676,mq://127.0.0.1:7676");
            Destination cardsQueue = context.createTopic("Topic");
            consumer = context.createConsumer(cardsQueue);
            consumer.setMessageListener(this);
            System.out.println("Listening to Topic...");
            // wait for messages
            Thread.sleep(300000);
        } catch (InterruptedException e){
            System.out.println("Error: " + e.getMessage());
        }
        catch (com.sun.messaging.jms.JMSException e){
            System.out.println("Error: " + e.getMessage());
        }
    }

    @Override
    public void onMessage(javax.jms.Message msg) {
        try{
            System.out.println(msg.getBody(String.class));
        } catch (com.sun.messaging.jms.JMSException e){
            System.err.println("JMSException: " + e.toString());
        } catch (javax.jms.JMSException e) {
            e.printStackTrace();
        }
    }
    public static void main(String[] args) throws javax.jms.JMSException {
        new receiver2();
    }
}
